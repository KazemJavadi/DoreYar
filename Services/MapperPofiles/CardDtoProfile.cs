using AutoMapper;
using DTOs;
using Entities;

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
