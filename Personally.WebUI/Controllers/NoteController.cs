using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Personally.Business.Abstract;
using Personally.Entities;

namespace Personally.WebUI.Controllers
{
    public class NoteController : Controller
    {
        private INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            Note noteDetail = _noteService.GetById((int)id);
            return View(noteDetail);
        }
    }
}