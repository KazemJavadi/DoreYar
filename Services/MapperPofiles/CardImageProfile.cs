using AutoMapper;
using DataAccess.Entities;
using Services.DTOs;

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
