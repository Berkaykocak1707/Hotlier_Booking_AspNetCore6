using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Hotlier_Booking_AspNetCore6.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingDtoForCreation, Booking>();
            CreateMap<BookingDtoForUpdate, Booking>().ReverseMap();
            CreateMap<ContactDtoForCreation, Contact>();
            CreateMap<RoomDtoForCreation, Room>();
            CreateMap<RoomDtoForUpdate, Room>().ReverseMap();
            CreateMap<SubscribeDtoForCreation, Subscribe>();
            CreateMap<UserDtoForCreation, IdentityUser>();
            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();
        }
    }
}
