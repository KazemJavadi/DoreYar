﻿using AutoMapper;
using DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MapperPofiles
{
    internal class CardImageDtoProfile:Profile
    {
        public CardImageDtoProfile()
        {
            CreateMap<CardImageDto, CardImage>();
        }
    }
}
