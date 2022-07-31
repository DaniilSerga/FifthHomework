using AutoMapper;
using Garage.Model.ViewModels;
using Garage.Model.DatabaseModels;

namespace Garage.Model.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DriverCreateViewModel, Driver>();
            CreateMap<DriverEditViewModel, Driver>();
        }
    }
}
