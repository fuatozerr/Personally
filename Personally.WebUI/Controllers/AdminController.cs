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
        private ICategoryService _categoryService;
        public AdminController(INoteService noteService,ICategoryService categoryService)
        {
            _noteService = noteService;
            _categoryService = categoryService;

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
            if(ModelState.IsValid)
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
            return View(); 
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

            if (ModelState.IsValid)
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
            return RedirectToAction("EditNote", model.Id);
        }

        public IActionResult DeleteNote(int deleteNote)
        {
            var entity = _noteService.GetById(deleteNote);
            _noteService.Delete(entity);
                return Redirect("ListNotes");
        }

        public IActionResult CategoryList()
        {
            return View(new CategoryListModel() {
                Categories=_categoryService.GetAllCategories()
            }
            );
        }

        public IActionResult EditCategory(int id)
        {
            var entity = _categoryService.GetByWithNotes(id);
            return View(new CategoryModel()
            {
                Id=entity.Id,
                Title=entity.Title,
                Notes=entity.noteCategories.Select(x=>x.Note).ToList()
            });
        }
        [HttpPost]
        public IActionResult EditCategory(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.Id);

            entity.Title = model.Title;
            _categoryService.Update(entity);
            return RedirectToAction("CategoryList");
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            var entity = new Category()
            {
                Title = model.Title
            };
            _categoryService.Create(entity);
            return RedirectToAction("CategoryList");
        }


        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            _categoryService.Delete(entity);
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteFromCategory(int categoryId, int noteId)
        {
            _categoryService.DeleteFromCategory(categoryId, noteId);
            return Redirect("EditCategory/"+categoryId);
        }
    }
}