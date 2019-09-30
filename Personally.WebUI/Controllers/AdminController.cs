﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personally.Business.Abstract;
using Personally.Entities;
using Personally.WebUI.Models;

namespace Personally.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private INoteService _noteService;
        public AdminController(INoteService noteService)
        {
            _noteService = noteService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateNote()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote(NoteModel model,IFormFile file )
        {
            if(file!=null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\img", file.FileName);

                using(var stream=new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                var entity = new Note
                {
                    Title = model.Title,
                    Description = model.Description,
                    ImageUrl = file.FileName,
                    IsDraft = model.IsDraft,
                    Owner = model.Owner
                };
                _noteService.Create(entity);
                
            }
            return Redirect("ListNotes");
        }


        public IActionResult ListNotes()
        {
            return View(new NoteListModel() {
                Notes=_noteService.GetAll()
            });
        }
    }
}