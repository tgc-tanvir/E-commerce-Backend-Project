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
    public class CustomerService
    {
        public static List<CustomerDTO> Get()
        {
            var data = DataAccessFactory.CustomerData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CustomerDTO>>(data);
            return mapped;
        }
        public static CustomerDTO Get(int id)
        {
            var data = DataAccessFactory.CustomerData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CustomerDTO>(data);
            return mapped;
        }

        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<CustomerDTO, Customer>();
            });
            return new Mapper(config);
        }
        public static bool Create(CustomerDTO c)
        {
            var repo = DataAccessFactory.CustomerData();
            var customer = GetMapper().Map<Customer>(c);
            return repo.Create(customer);
        }
        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.CustomerData();
            return repo.Delete(id);
        }
        public static bool Update(CustomerDTO c)
        {
            var repo = DataAccessFactory.CustomerData();

            var update = GetMapper().Map<Customer>(c);

            return repo.Update(update);
        }
    }
}
