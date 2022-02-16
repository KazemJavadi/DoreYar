using AutoMapper;
using DTOs;
using Entities;

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
