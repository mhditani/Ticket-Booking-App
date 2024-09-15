using AutoMapper;
using TicketBooking.Entities;
using TiketBooking.Web.ViewModels.BusVM;

namespace TiketBooking.Web.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Bus, BusViewModel>();
            CreateMap<CreateBusViewModel, Bus>().ForMember(dest => dest.BusImage, opt => opt.Ignore());

            CreateMap<Bus, EditBusViewModel>().ForMember(dest => dest.BusImage, opt => opt.Ignore());

            CreateMap<EditBusViewModel, Bus>().ForMember(dest => dest.BusImage, opt => opt.Ignore());
        }

    }
}
