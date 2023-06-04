using BookShop.Application.Repositories;
using BookShop.Domain.Models;
using BookShop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public  interface IOrderService
    {
        
        List<Order> GetOrders(FilterOptions options);

        Order GetOrderById(int id);

        Order AddNewOrder(CreateOrderDto dto);
    }
}
