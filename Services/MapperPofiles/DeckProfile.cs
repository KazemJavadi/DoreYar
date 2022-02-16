using AutoMapper;
using DTOs;
using Entities;

namespace Services.MapperPofiles
{
    internal class DeckProfile : Profile
    {
        public DeckProfile()
        {
            CreateMap<Deck, DeckDto>();
        }
    }
}
