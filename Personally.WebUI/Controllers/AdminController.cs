using System;
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


        public IActionResult EditNote(int id)
        {
            var entity = _noteService.GetById((int)id);

            var model = new NoteModel()
            {
                Id=entity.Id,
                Title=entity.Title,
                Description=entity.Description,
                ImageUrl=entity.ImageUrl,
                Owner=entity.Owner
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditNote(NoteModel model,IFormFile file)
        {
            var entity = _noteService.GetById(model.Id);

            entity.ImageUrl = model.ImageUrl;
            entity.IsDraft = model.IsDraft;
            entity.Owner = model.Owner;
            entity.Title = model.Title;
            entity.Description = model.Description;

            if (file != null)
            {
                entity.ImageUrl = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            _noteService.Update(entity);
            return RedirectToAction("EditNote", entity);
        }
    }
}