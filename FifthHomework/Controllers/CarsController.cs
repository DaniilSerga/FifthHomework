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
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/Cars
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetCars() => Ok(_carService.GetCars());

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public ActionResult GetCar(int id) => Ok(_carService.Get(id));

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public IActionResult PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _carService.Update(id, car);

            return Ok();
        }

        // POST: api/Cars
        [HttpPost]
        public IActionResult PostCar(Car car)
        {
            _carService.Create(car);

            return Ok();
        }

        // DELETE: api/Cars/5
        [HttpDelete]
        public IActionResult DeleteCar(int id)
        {
            _carService.Delete(id);

            return Ok();
        }
    }
}
