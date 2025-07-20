using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repos
{
    internal class OrderDetailRepo : Repo, IRepo<OrderDetail, int, bool>
    {
        public bool Create(OrderDetail obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> Read()
        {
            return db.OrderDetails.ToList();
        }

        public OrderDetail Read(int id)
        {
            return db.OrderDetails.Find(id);
        }

        public bool Update(OrderDetail obj)
        {
            throw new NotImplementedException();
        }
    }
}
