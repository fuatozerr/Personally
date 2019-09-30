using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Personally.Business.Abstract;
using Personally.Entities;
using Personally.WebUI.Models;

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

            Note noteDetail = _noteService.GetNoteDetail((int)id);
            if(noteDetail==null)
            {
                return NotFound();
            }


            return View(new NoteDetailModel()
            {
                Note=noteDetail,
                Categories=noteDetail.noteCategories.Select(x=>x.Category).ToList(),
                Comments=noteDetail.Comments

            });;
        }


        public IActionResult AddNote()
        {
            return View();
        }

        public IActionResult List(string category,int page=1)
        {
            const int pageSize = 2;
            return View(new NoteListModel()
            {
                 PageInfo=new PageInfo()
                 {
                     TotalItems=_noteService.GetCounByCategory(category),
                     CurrentPage=page,
                     ItemsPerPage=pageSize,
                     CurrentCategory=category
                 },

                Notes=_noteService.GetNotesByCategory(category, page,pageSize)
            });;
        }

    }
}