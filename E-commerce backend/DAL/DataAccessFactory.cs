using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Product, int, bool> ProductData() {
            return new ProductRepo();
        }
        public static IRepo<Order, int, bool> OrderData()
        {
            return new OrderRepo();
        }
        public static IRepo<Customer, int, bool> CustomerData()
        {
            return new CustomerRepo();
        }
        public static IRepo<Employee, int, Employee> EmployeeData()
        {
            return new EmployeeRepo();
        }
        public static IRepo<OrderDetail, int, bool> OrderDetailData()
        {
            return new OrderDetailRepo();
        }
        public static IRepo<Status, int, bool> StatusData()
        {
            return new StatusRepo();
        }
        public static IRepo<Cart, int, bool> CartData()
        {
            return new CartRepo();
        }
        public static IAuth<bool> AuthData()
        {
            return new CustomerRepo();
        }
        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
    }
}
