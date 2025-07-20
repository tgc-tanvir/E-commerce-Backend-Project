using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repos
{
    internal class StatusRepo : Repo, IRepo<Status, int, bool>
    {
        public bool Create(Status obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Status> Read()
        {
            return db.Statuses.ToList();
        }

        public Status Read(int id)
        {
            return db.Statuses.Find(id);
        }

        public bool Update(Status obj)
        {
           throw new NotImplementedException();
        }
    }
}
