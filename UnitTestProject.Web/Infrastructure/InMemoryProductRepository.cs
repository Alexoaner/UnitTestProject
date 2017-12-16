
using System.Collections.Generic;
using System.Linq;
using UnitTestProject.Web.Models;
using UnitTestProject.Web.Repositorys;

namespace UnitTestProject.Web.Infrastructure
{
    public class InMemoryProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>{
            new Product {ID = 1 , Name = "Apples", Price = 1.50m },
            new Product {ID = 1 , Name = "Bananas", Price = 2.00m }
        };

        public Product GetProductById(int id)
        {
            return products.Where(p => p.ID == id).FirstOrDefault();
        }

        public List<Product> ListProducts()
        {
            return products;
        }
    }
}