using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Garage.Model;
using Garage.Model.DatabaseModels;
using Garage.BusinessLogic.Services.Contracts;
using System.Security.Cryptography;
using System.Text;
using Garage.Model.DTOModels;

namespace Garage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        // GET: api/Drivers
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetDrivers() => Ok(_driverService.GetDrivers());

        // GET: api/Drivers/5
        [HttpGet("{id}")]
        public ActionResult GetDriver(int id) => Ok(_driverService.Get(id));

        // PUT: api/Drivers/5
        [HttpPut("{id}")]
        public IActionResult PutDriver(int id, Driver driver)
        {
            if (id != driver.Id)
            {
                return BadRequest();
            }

            _driverService.Update(id, driver);

            return Ok();
        }

        // POST: api/Drivers
        [HttpPost("register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            if (_driverService.DriverExists(registerDto.Name))
            {
                return BadRequest("This name is already taken.");
            }

            var hmac = new HMACSHA512();

            var driver = new Driver
            {
                Name = registerDto.Name,
                Age = registerDto.Age,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _driverService.Create(driver);

            return Ok();
        }

        [HttpPost("login")]
        public ActionResult<Driver> Login(LoginDto loginDto)
        {
            var driver = _driverService.Get(loginDto.Name);

            if (driver is null)
            {
                return BadRequest("Invalid driver's name.");
            }

            var hmac = new HMACSHA512(driver.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != driver.PasswordHash[i])
                {
                    return Unauthorized("Invalid password");
                }
            }

            return driver;
        }

        // DELETE: api/Drivers/5
        [HttpDelete]
        public IActionResult DeleteDriver(int id)
        {
            _driverService.Delete(id);

            return Ok();
        }
    }
}
