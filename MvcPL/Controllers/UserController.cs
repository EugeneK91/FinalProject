using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface;
using DAL.DTO;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models.UserModel;

namespace MvcPL.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Edit(bool isPartial = true)
        {
            var user = CurrentUser.ToUserViewModel();
            Session["UserPhoto"] = user.Photo;
            ViewBag.isPartial = isPartial;
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Photo")]UserViewModel model,HttpPostedFileBase Photo)

        {
            
            if(Photo == null)
                model.Photo = (byte[])Session["UserPhoto"];
            else
            {
                model.Photo = Photo.HttpPostedFileBasePhotoToByteArray();
                Session["Photo"] = Photo.HttpPostedFileBasePhotoToByteArray();
            }
            _userService.UpdateUser(model.ToBllUserMOdel());
            if(Request.IsAjaxRequest())
            return Json(true);
            ViewBag.isPartial = false;
            return View(CurrentUser.ToUserViewModel());
        }

        private UserEntity CurrentUser => _userService.GetUserByEmail(User.Identity.Name);
    }
}