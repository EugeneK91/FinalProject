using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using DAL.Interface;
using System.Drawing;
using Entity;

namespace DAL.DTO
{
    public class UserEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
    }
}
