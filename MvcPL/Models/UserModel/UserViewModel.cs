using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MvcPL.Models.UserModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required field Name")]
        public string Name { get; set; }
        public int? RoleId { get; set; }
        [Required(ErrorMessage = "Required field Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required field Password")]
        public string Password { get; set; }
        public byte[] Photo { get; set; }
    }
}