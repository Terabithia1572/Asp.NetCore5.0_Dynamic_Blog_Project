using BusinessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();
        public void CategoryAdd(Category category)
        {
            repo.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            if(category.CategoryID !=0) { 
            repo.Delete(category);
            }
        }

        public void CategoryUpdate(Category category)
        {
            repo.Update(category);
        }

        public Category GetByID(int id)
        {
            return repo.GetByID(id);
        }

        public List<Category> GetList()
        {
            return repo.GetListAll();
        }
    }
}
