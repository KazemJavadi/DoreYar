using AutoMapper;
using DTOs;
using Entities;

namespace Services.MapperPofiles
{
    internal class CardImageProfile : Profile
    {
        public CardImageProfile()
        {
            CreateMap<CardImage, CardImageDto>();
        }
    }
}
