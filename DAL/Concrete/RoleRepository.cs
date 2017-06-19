using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.Interface;
using Entity;


namespace DAL.Concreate
{
    public class RoleRepository:IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Role> GetAll()
        {
            return context.Set<Role>();
        }

        public Role GetById(int roleId)
        {
            return context.Set<Role>().Find(roleId);
        }

        public IEnumerable<Role> GetByPredicate(Expression<Func<Role, bool>> f)
        {
            return context.Set<Role>().Where(f);
        }

        public Role GetFirstByPredicate(Expression<Func<Role, bool>> f)
        {
            return context.Set<Role>().FirstOrDefault(f);
        }

        public void Create(Role role)
        {
            context.Set<Role>().Add(new Role()
            {
                Name = role.Name,
                Description = role.Description
            });

        }

        public void Delete(Role r)
        {
            var user = context.Set<Role>().Find(r.Id);
            context.Set<Role>().Remove(user);
        }

        public void Update(Role r)
        {
            var role = context.Set<Role>().Find(r.Id);

            role.Name = r.Name;
            role.Description = r.Description;

            context.Set<Role>().AddOrUpdate(role);
        }
    }
}
