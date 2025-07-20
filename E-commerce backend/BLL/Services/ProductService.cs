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
    public class ProductService
    {
        public static List<ProductDTO> Get() {
            var data = DataAccessFactory.ProductData().Read();
            var cfg = new MapperConfiguration(c =>{ 
             c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ProductDTO>>(data);
            return mapped;
        }
        public static ProductDTO Get(int id) {
            var data = DataAccessFactory.ProductData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductDTO>(data);
            return mapped;
        }
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
            });
            return new Mapper(config);
        }
        public static bool Create(ProductDTO p)
        {
            var repo = DataAccessFactory.ProductData();
            var product = GetMapper().Map<Product>(p);
            return repo.Create(product);
        }
        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.ProductData();
            return repo.Delete(id);
        }
        public static bool Update(ProductDTO p)
        {
            var repo = DataAccessFactory.ProductData();

            var update = GetMapper().Map<Product>(p);

            return repo.Update(update);
        }
    }
}
