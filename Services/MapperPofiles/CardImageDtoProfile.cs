using AutoMapper;
using DataAccess.Entities;
using Services.DTOs;

namespace Services.MapperPofiles
{
    internal class CardImageDtoProfile : Profile
    {
        public CardImageDtoProfile()
        {
            CreateMap<CardImageDto, CardImage>();
        }
    }
}
