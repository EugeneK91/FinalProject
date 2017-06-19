using System.Collections.Generic;
using ORM;
using System.Data.Entity;
using Entity;


namespace MvcPL.Initializer
{
    public class AudioCardFileDbInitializer : CreateDatabaseIfNotExists<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            var roles = new List<Role>
            {
                new Role() { Name = "Admin",Description = "main role"},
                new Role() {Name = "Moderator",Description = "middle role" },
                new Role() {Name = "User",Description = "the lowest role"},

            };

            var user = new User()
            {
                Role = roles[0],
                Name = "Oleg",
                Email = @"Oleg@mail.ru",
                Password = "123456",
                Photo = new byte[] {},
                RoleId = 1
            };


            context.Set<Role>().AddRange(roles);
            context.Set<User>().Add(user);


            base.Seed(context);
        }
    }
}