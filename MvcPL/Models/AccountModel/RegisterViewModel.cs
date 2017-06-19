
using System.ComponentModel.DataAnnotations;
using MvcPL.Infrastructure.Enums;
using System.Web;


namespace MvcPL.Models.AccountModel
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            RoleId = (int)Role.User;
        }
        [Required(ErrorMessage = "Required field Name")]
        [Display(Name= "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required field Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage = "Wrong email adress")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required field Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required field ConfirmPassword")]
        [Compare("Password",ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Photo")]
        public HttpPostedFileBase Photo { get; set; }
        public int RoleId { get; set; }

    }
}