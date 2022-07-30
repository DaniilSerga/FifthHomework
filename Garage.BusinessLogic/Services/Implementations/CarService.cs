using Garage.BusinessLogic.Services.Contracts;
using Garage.Model.DatabaseModels;
using Garage.Model;
using Microsoft.EntityFrameworkCore;

namespace Garage.BusinessLogic.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ApplicationContext _context;

        public CarService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Car> GetCars() => _context.Cars.AsNoTracking().ToList();

        public Car Get(int id)
        {
            var car =  _context.Cars.FirstOrDefault(u => u.Id == id);

            if (car is null)
            {
                throw new ArgumentException("Car with current Id doesn't exist", nameof(id));
            }

            return car;
        }

        public void Create(Car car)
        {
            if (car is null)
            {
                throw new ArgumentNullException(nameof(car), "Car variable cannot be null.");
            }

            _context.Cars.Add(car);

            _context.SaveChanges();
        }

        public void Update(int id, Car car)
        {
            if (car is null)
            {
                throw new ArgumentNullException(nameof(car), "Car variable cannot be null.");
            }

            var dbCar = _context.Cars.FirstOrDefault(u => u.Id == id);

            if (dbCar is null)
            {
                throw new ArgumentException("Car with current Id doesn't exist.");
            }

            dbCar = car;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var car = _context.Cars.FirstOrDefault(u => u.Id == id);

            if (car is null)
            {
                throw new ArgumentNullException(nameof(id), "Car with current Id doesn't exist.");
            }

            _context.Cars.Remove(car);

            _context.SaveChanges();
        }
    }
}
