using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using MvcPL.Models.UserModel;

namespace MvcPL.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: User
        public ActionResult Edit()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RenderUserTable(int page = 1)
        {
            var users = _userService.GetAllUsers();
            if (users == null)
            {
                return View("UserTable", null);
            }
            var model = CreateModel(page,users);
            return View("UserTable", model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RenderPartialUserTable(int page = 1)
        {
            var model = CreateModel(page, _userService.GetAllUsers());
            return PartialView("_UserTable", model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            if(Request.IsAjaxRequest())
            return Json(true, JsonRequestBehavior.AllowGet);

            return RenderUserTable();
        }

        private IndexViewModel<UserViewModel> CreateModel(int page,IEnumerable<DAL.DTO.UserEntity> users)
        {
            var viewUsers = users.Skip((page - 1) * 10).Take(10).Select(c => c.ToUserViewModel());
            var pageInfo = new PageInfo() { PageNumber = page, TotalItems = users.Count(), PageSize = 10 };
            var model = new IndexViewModel<UserViewModel>() { Items = viewUsers, PageInfo = pageInfo };
            return model;
        }
    }
}