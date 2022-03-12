using AutoMapper;
using Services.DTOs;
using DataAccess.Entities;

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
