using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface;
using Entity;

namespace DAL.Concrete
{
    public class UserRepository:IUserRepository
    {
        private readonly DbContext context;
        public UserRepository(DbContext context)
        {
            this.context = context;
        }
        public IEnumerable<User> GetAll()
        {
            return context.Set<User>().ToList();
        }

        public User GetById(int userId)
        {
            var user =  context.Set<User>().Find(userId);
            return user;

        }


        public IEnumerable<User> GetByPredicate(Expression<Func<User, bool>> f)
        {
            return context.Set<User>().Where(f);
        }

        public User GetFirstByPredicate(Expression<Func<User, bool>> f)
        {
            return context.Set<User>().FirstOrDefault(f);
        }

        public void Create(User user)
        {
            context.Set<User>().Add(new User()
            {
                Name = user.Name,
                RoleId = user.RoleId,
                Email = user.Email,
                Password =user.Password,
                Photo = user.Photo
            });

        }

        public void Delete(User u)
        {
            var user = context.Set<User>().Find(u.Id);
            context.Set<User>().Remove(user);
        }

        public void Update(User u)
        {
            var user = context.Set<User>().Find(u.Id);

            user.Name = u.Name;
            user.RoleId = u.RoleId;
            user.Photo = u.Photo;
            user.Email = u.Email;
            
            context.Set<User>().AddOrUpdate(user);
        }
    }
}
