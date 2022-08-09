using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BlogRepository : IBlogDal
    {
        public void AddBlog(Blog blog)
        {
            using var context = new Context();
            context.Add(blog);
            context.SaveChanges();
        }

        public void Delete(Blog t)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlog(Blog blog)
        {
            using var context = new Context();
            context.Remove(blog);
            context.SaveChanges();
        }

        public Blog GetByID(int id)
        {
            using var context = new Context();
            return context.Blogs.Find(id);
        }

        public List<Blog> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Blog t)
        {
            throw new NotImplementedException();
        }

        public List<Blog> ListAllBlog()
        {
            using var context = new Context();
           return context.Blogs.ToList();
        }

        public void Update(Blog t)
        {
            throw new NotImplementedException();
        }

        public void UpdateBlog(Blog blog)
        {
            using var context = new Context();
            context.Update(blog);
            context.SaveChanges();
        }
    }
}
