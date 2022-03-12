using AutoMapper;
using DataAccess.Entities;
using Services.DTOs;

namespace Services.MapperPofiles
{
    internal class DeckDtoProfile : Profile
    {
        public DeckDtoProfile()
        {
            CreateMap<DeckDto, Deck>();
        }
    }
}
