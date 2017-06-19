using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public partial class User:  IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Byte[] Photo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
