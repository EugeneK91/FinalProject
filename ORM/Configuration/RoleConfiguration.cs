using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;


namespace ORM.Configuration
{
    public class RoleConfiguration:EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            HasMany(c => c.Users).WithOptional(c => c.Role).HasForeignKey(c => c.RoleId);
        }
    }
}
