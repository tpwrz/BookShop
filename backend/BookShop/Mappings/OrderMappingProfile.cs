using AutoMapper;
using BookShop.Domain.Models;
using BookShop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Mappings
{
    public class OrderMappingProfile :Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}
