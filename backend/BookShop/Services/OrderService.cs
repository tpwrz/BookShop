using BookShop.Application.Repositories;
using BookShop.Domain.Models;
using BookShop.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public class OrderService : IOrderService
    {

        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Order AddNewOrder(CreateOrderDto dto)
        {
            if (CheckIfIdExists((int)dto.Id))
                return null;

            var order = new Order
            {
                Id = (int)dto.Id,
                ShippingAdr = dto.ShippingAdr,
                CartId = (int)dto.CartId,
                Quantity = (int)dto.Quantity,
                OrderstatusId = (int)dto.OrderstatusId,
                OrderDate = (DateTime)dto.OrderDate,
                OrderPrice = dto.OrderPrice,
            };

            _orderRepository.Add(order);
            _orderRepository.Save();
            return order;
        }

        private bool CheckIfIdExists(int id)
        {
            return _orderRepository.Find(x => x.Id == id) != null;
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.Find(id);
        }

        public List<Order> GetOrders(FilterOptions options)
        {
            IQueryable<Order> orders;

            if (!string.IsNullOrWhiteSpace(options.SearchTerm))
            {
                orders = _orderRepository.FindAll(e => e.ShippingAdr.Contains(options.SearchTerm));
            }
            else
            {
                orders = _orderRepository.GetAll();
            }

            switch (options.Order)
            {
                case SortOrder.Ascending:
                    orders = orders.OrderBy(e => e.ShippingAdr);
                    break;
                case SortOrder.Descending:
                    orders = orders.OrderByDescending(e => e.ShippingAdr);
                    break;
            }

            return orders.ToList();
        }
    }
}
