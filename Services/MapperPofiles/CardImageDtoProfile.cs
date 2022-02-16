using AutoMapper;
using DTOs;
using Entities;

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
