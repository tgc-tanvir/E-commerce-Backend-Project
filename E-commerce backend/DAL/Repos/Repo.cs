using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repos
{
    internal class Repo
    {
        internal ECommerceContext db;
        internal Repo()
        {
          db = new ECommerceContext();
        }
    }
}
