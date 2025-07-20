using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repos
{
    internal class CartRepo : Repo, IRepo<Cart, int, bool>
    {
        public bool Create(Cart obj)
        {
            db.Carts.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Carts.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Cart> Read()
        {
            return db.Carts.ToList();
        }

        public Cart Read(int id)
        {
            return db.Carts.Find(id);
        }

        public bool Update(Cart obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
