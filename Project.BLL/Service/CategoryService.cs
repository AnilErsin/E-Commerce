using Project.BLL.Repository;
using Project5.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Service
{

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void CreateCategory(Category category)
        {
            categoryRepository.Insert(category);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return categoryRepository.GetAll().ToList();
        }

        public Category GetById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public void RemoveCategory(Category category)
        {
            categoryRepository.Remove(category);
        }

        public void UpdateCategory(Category category)
        {
            categoryRepository.Update(category);
        }
    }
}
