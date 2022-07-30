using Garage.Model.DatabaseModels;

namespace Garage.BusinessLogic.Services.Contracts
{
    public interface IDriverService
    {
        List<Driver> GetDrivers();
        Driver Get(int id);
        void Create(Driver driver);
        void Update(int id, Driver driver);
        void Delete(int id);
    }
}
