using AutoMapper;
using DataAccess.Entities;
using Services.DTOs;

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
