using AutoMapper;
using DataAccess.Entities;
using Services.DTOs;

namespace Services.MapperPofiles
{
    internal class CardDtoProfile : Profile
    {
        public CardDtoProfile()
        {
            CreateMap<CardDto, Card>();
        }
    }
}
