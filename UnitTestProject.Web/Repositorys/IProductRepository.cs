
using System.Collections.Generic;
using UnitTestProject.Web.Models;

namespace UnitTestProject.Web.Repositorys
{
    public interface IProductRepository
    {
        List<Product> ListProducts();

        Product GetProductById(int id);
    }
}