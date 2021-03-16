using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.BLL;
using ProjectMVC.Core.Interfaces;
using ProjectMVC.Data.Models;
using ProjectMVC.Data.Repositoryes;
using ProjectMVC.Models.ViewModels;

namespace ProjectMVC.Controllers
{
    public class PostController : Controller
    {
        private IRepository<Post> _repository;
        public PostController(IRepository<Post> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(PostViewModel postViewModel)
        {
            PostBL postBL = new PostBL((PostRepository)this._repository);
            postBL.CreatePost(postViewModel);
            return RedirectToAction("AccountController/Index");
        }

    }
}