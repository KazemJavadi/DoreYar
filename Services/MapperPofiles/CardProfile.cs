using AutoMapper;
using DataAccess.Entities;
using Services.DTOs;

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
