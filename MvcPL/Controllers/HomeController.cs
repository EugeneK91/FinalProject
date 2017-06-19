using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BLL;
using BLL.Interface;
using Logger;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using MvcPL.Models.AccountModel;

namespace MvcPL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAudioFileService _audioFileService;
        private readonly IAudioRatingService _audioRatingService;

        public HomeController(IUserService userService,IAudioFileService audioFileService,IAudioRatingService audioRatingService)
        {
            _userService = userService;
            _audioFileService = audioFileService;
            _audioRatingService = audioRatingService;
        }
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult RenderTable(int page = 1)
        {
            var audioFiles = _audioFileService.GetAllFiles();
            if (audioFiles == null)
            {
                return PartialView("_AudioTable", null);
            }
            var viewAudioFiles = audioFiles.Skip((page - 1) * 10).Take(10).Select(c => c.ToMvcAudioFile());
            var pageInfo = new PageInfo() {PageNumber = page,PageSize = 10,TotalItems = audioFiles.Count()};
            var model = new IndexViewModel<AudioFileViewModel>() {Items = viewAudioFiles, PageInfo = pageInfo};
            return PartialView("_AudioTable", model);
        }

        [HttpGet]
        public ActionResult AddAudioFile(int? id=null)
        {
            if (id == null) {
                if (Request.IsAjaxRequest()) {
                    ViewBag.isPartial = true;
                    return PartialView();
                }
                ViewBag.isPartial = false;
                return View();
            }
            var model = _audioFileService.GetById(id.Value).ToMvcAudioFile();
            TempData["Body"] = model.Body;
            if (Request.IsAjaxRequest())
            {
                ViewBag.isPartial = true;
                return PartialView(model);
            }

            ViewBag.isPartial = false;
            return View(model);
        }


        [HttpPost]
        public ActionResult AddAudioFile(AudioFileViewModel model)
        {
            if (model.Id!=0 && (model.Body == null || model.Body.ContentLength==0) )
            model.Body = (HttpPostedFileBase) TempData["Body"];
            _audioFileService.SaveFile(model.ToBllAudioFile());
            if(Request.IsAjaxRequest())
            return Json(true,JsonRequestBehavior.AllowGet);
            return View("Index");
        }

        [AllowAnonymous]
        public FileResult StreamTrack(int id)
        {
            var file = _audioFileService.GetById(id).Body;
            return File(file.ToArray(), "audio/mp3");
        }

        [HttpPost]
        public ActionResult SetRating(int songId,decimal rating)
        {
            var userId = _userService.GetUserByEmail(User.Identity.Name).Id;
            _audioRatingService.SetRating(songId,rating,userId);
            return null;
        }

        public ActionResult GetRating(int songId)
        {
            var userId = _userService.GetUserByEmail(User.Identity.Name).Id;
            var rating =_audioRatingService.GetRating(songId, userId);
            return Json(rating, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete(int id)
        {
            _audioFileService.DeleteFile(id);
            if(Request.IsAjaxRequest())
            return Json(true, JsonRequestBehavior.AllowGet);
            return View("Index");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Search(SearchModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                var arrayMessages = ModelState.Values.SelectMany(c => c.Errors).Select(c => c.ErrorMessage).ToArray();
                if (Request.IsAjaxRequest())
                    return Json(new { message = arrayMessages }, JsonRequestBehavior.DenyGet);
                return View("Index");
            }

                var result = _audioFileService.SerchAudioFiles(model.ToBllSearchModel()).Select(c => c.ToMvcAudioFile());
                var pageInfo = new PageInfo { PageNumber = 1, PageSize = !result.Any() ? 1 : result.Count(), TotalItems = result.Count() };
                var viewModel = new IndexViewModel<AudioFileViewModel>() { Items = result, PageInfo = pageInfo };
            if(Request.IsAjaxRequest())
                return PartialView("_AudioTable", viewModel);
            return View("AudioTable", viewModel);

        }

    }
}