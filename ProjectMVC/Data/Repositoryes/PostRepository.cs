using ProjectMVC.Core.Interfaces;
using ProjectMVC.Data.Context;
using ProjectMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Data.Repositoryes
{
    public class PostRepository : IRepository<Post>
    {
        private readonly ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Post entity)
        {
            _context.Posts.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Post entity)
        {
            GetById(entity.PostId).IsDeleted = true;
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            GetById(id).IsDeleted = true;
            _context.SaveChanges();
        }

        public Post GetById(int id)
        {
           return  _context.Posts.Find(id);
            
        }

        public IEnumerable<Post> List()
        {
            return _context.Posts;
        }

        public void Update(Post entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
