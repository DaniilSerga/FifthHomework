using Garage.BusinessLogic.Services.Contracts;
using Garage.Model.DatabaseModels;
using Garage.Model;
using Microsoft.EntityFrameworkCore;

namespace Garage.BusinessLogic.Services.Implementations
{
    public class DriverService : IDriverService
    {
        private readonly ApplicationContext _context;

        public DriverService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Driver> GetDrivers() => _context.Drivers.AsNoTracking().ToList();

        public Driver Get(int id)
        {
            var driver = _context.Drivers.FirstOrDefault(u => u.Id == id);

            if (driver is null)
            {
                throw new ArgumentException("Driver with current Id doesn't exist.");
            }

            return driver;
        }

        public Driver? Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Name was null or empty.");
            }

            return _context.Drivers.FirstOrDefault(x => x.Name == name);
        }

        public bool DriverExists(string name) => _context.Drivers.Any(x => x.Name.ToLower() == name.ToLower());

        public void Create(Driver driver)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(nameof(driver), "Driver variable cannot be null.");
            }

            _context.Drivers.Add(driver);

            _context.SaveChanges();
        }

        public void Update(int id, Driver driver)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(nameof(driver), "Driver variable cannot be null.");
            }

            var dbDriver = _context.Drivers.FirstOrDefault(u => u.Id == id);

            if (dbDriver is null)
            {
                throw new ArgumentException("Driver with current id doesn't exist.");
            }

            dbDriver = driver;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var driver = _context.Drivers.FirstOrDefault(u => u.Id == id);

            if (driver is null)
            {
                throw new ArgumentException("Driver with current Id doesn't exist.", nameof(id));
            }

            _context.Drivers.Remove(driver);

            _context.SaveChanges();
        }

    }
}
