using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace ORM.Configuration
{
    class UserConfiguration: EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasOptional(c => c.Role).WithMany(c => c.Users).HasForeignKey(c=>c.RoleId);
        }

    }
}
