using AutoMapper;
using DTOs;
using Entities;

namespace Services.MapperPofiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardDto>();
        }
    }
}
