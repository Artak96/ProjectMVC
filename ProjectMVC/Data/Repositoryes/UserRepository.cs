using ProjectMVC.Core.Interfaces;
using ProjectMVC.Data.Context;
using ProjectMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Data.Repositoryes
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            GetById(entity.UserId).IsDeleted = true;
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            GetById(id).IsDeleted = true;
            _context.SaveChanges();
        }

        public User GetById(int id)
        {
            var user = _context.Find<User>(id);
            return user;
        }

        public IEnumerable<User> List()
        {
            return _context.Users;
        }

        public void Update(User entity)
        {
             _context.Update(entity);
        }
    }
}
