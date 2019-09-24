using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Personally.Business.Abstract;
using Personally.WebUI.Models;

namespace Personally.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private INoteService _noteService;
        public HomeController(INoteService noteService)
        {
            _noteService = noteService;
        }
        public IActionResult Index()
        {
            return View(new NoteListModel()
            {
                Notes=_noteService.GetAll()
            });
        }
    }
}