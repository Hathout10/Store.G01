﻿using AutoMapper;
using Store.G01.Core.Dtos.Basket;
using Store.G01.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G01.Core.Mapping.Basket
{
	public class BasketProfile : Profile
	{
        public BasketProfile()
        {
             CreateMap<CustomerBasket,CustomerBasketDto>().ReverseMap();
        }
    }
}
