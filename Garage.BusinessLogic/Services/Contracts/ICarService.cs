using Garage.Model.DatabaseModels;

namespace Garage.BusinessLogic.Services.Contracts
{
    public interface ICarService
    {
        List<Car> GetCars();
        Car Get(int id);
        void Create(Car car);
        void Update(int id, Car car);
        void Delete(int id);
    }
}
