using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;

namespace BLL.Services
{
    public class OrderService
    {
        public static List<OrderDTO> Get()
        {
            var data = DataAccessFactory.OrderData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrderDTO>>(data);
            return mapped;
        }
        public static OrderDTO Get(int id)
        {
            var data = DataAccessFactory.OrderData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderDTO>(data);
            return mapped;
        }
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderDTO, Order>();
            });
            return new Mapper(config);
        }
        public static bool Create(OrderDTO o)
        {
            var repo = DataAccessFactory.OrderData();
            var order = GetMapper().Map<Order>(o);
            return repo.Create(order);
        }
        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.OrderData();
            return repo.Delete(id);
        }
        public static bool Update(OrderDTO o)
        {
            var repo = DataAccessFactory.OrderData();

            var update = GetMapper().Map<Order>(o);

            return repo.Update(update);
        }
    }
}
