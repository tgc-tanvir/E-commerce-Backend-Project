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
    public class CartService
    {
        public static List<CartDTO> Get()
        {
            var data = DataAccessFactory.CartData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Cart, CartDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CartDTO>>(data);
            return mapped;
        }
        public static CartDTO Get(int id)
        {
            var data = DataAccessFactory.CartData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Cart, CartDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CartDTO>(data);
            return mapped;
        }
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cart, CartDTO>();
                cfg.CreateMap<CartDTO, Cart>();
            });
            return new Mapper(config);
        }
        public static bool Create(CartDTO c)
        {
            var repo = DataAccessFactory.CartData();
            var cart = GetMapper().Map<Cart>(c);
            return repo.Create(cart);
        }
        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.CartData();
            return repo.Delete(id);
        }
        public static bool Update(CartDTO c)
        {
            var repo = DataAccessFactory.CartData();

            var update = GetMapper().Map<Cart>(c);

            return repo.Update(update);
        }

    }
}
