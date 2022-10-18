using Project5.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProduct();

        void CreateProduct(Product product);
        void RemoveProduct(Product product);
        void UpdateProduct(Product product);

        Product GetById(int id);
    }
}
