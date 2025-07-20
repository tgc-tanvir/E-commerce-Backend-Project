using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repos
{
    internal class CustomerRepo : Repo, IRepo<Customer, int, bool>, IAuth<bool>
    {
        public bool Authenticate(string username, string password)
        {
            var data = db.Customers.FirstOrDefault(u=>u.Name.Equals(username) && 
            u.Password.Equals(password));
            if (data != null) return true;
            return false;
        }

        public bool Create(Customer obj)
        {
            db.Customers.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Customers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Customer> Read()
        {
            return db.Customers.ToList();
        }

        public Customer Read(int id)
        {
            return db.Customers.Find(id);
        }

        public bool Update(Customer obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
