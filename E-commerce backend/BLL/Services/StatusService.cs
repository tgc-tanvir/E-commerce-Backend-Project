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
    public class StatusService
    {
        public static List<StatusDTO> Get()
        {
            var data = DataAccessFactory.StatusData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Status, StatusDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<StatusDTO>>(data);
            return mapped;
        }
        public static StatusDTO Get(int id)
        {
            var data = DataAccessFactory.StatusData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Status, StatusDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<StatusDTO>(data);
            return mapped;
        }
    }
}
