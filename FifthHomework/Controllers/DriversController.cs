using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Garage.Model;
using Garage.Model.DatabaseModels;
using Garage.BusinessLogic.Services.Contracts;

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
        [HttpPost]
        public IActionResult PostDriver(Driver driver)
        {
            _driverService.Create(driver);

            return Ok();
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
