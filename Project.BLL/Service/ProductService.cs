using Project.BLL.Repository;
using Project5.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }
        public void CreateProduct(Product product)
        {
            productRepository.Insert(product);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return productRepository.GetAll().ToList();
        }

        public Product GetById(int id)
        {
            return productRepository.GetById(id);
        }

        public void RemoveProduct(Product product)
        {
            productRepository.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            productRepository.Update(product);
        }
    }
}
