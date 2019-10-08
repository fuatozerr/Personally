using Microsoft.EntityFrameworkCore;
using Personally.DataAccess.Abstract;
using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Personally.DataAccess.Concrete
{
    public class EfCoreNoteDal : EfCoreGenericRepository<Note, PersonallyContext>, INoteDal
    {
        public List<Note> GetAllNote()
        {
            throw new NotImplementedException();
        }

        public Note GetByIdWithCategories(int id)
        {
            using (var context =new PersonallyContext())
            {
                return context.Notes.Where(x => x.Id == id).Include(x => x.noteCategories).ThenInclude(x => x.Category).FirstOrDefault();
            }
        }

        public int GetCounByCategory(string category)
        {

            using (var context = new PersonallyContext())
            {
                var notes = context.Notes.AsQueryable(); //içinde sorgu yapılcak

                if (!string.IsNullOrEmpty(category))
                {
                    notes = notes.Include(x => x.noteCategories)
                        .ThenInclude(x => x.Category)
                        .Where(x => x.noteCategories.Any(a => a.Category.Title.ToLower() == category.ToLower()));
                }

                return notes.Count();
            }
        }

        public Note GetNoteDetail(int id)
        {
            using (var context=new PersonallyContext())
            {
                return context.Notes.Where(x=>x.Id==id)
                    .Include(x=>x.noteCategories).ThenInclude(x=>x.Category)
                    .Include(x=>x.Comments)               
                    .FirstOrDefault();
            }
        }
        public List<Note> GetNotesByCategory(string category, int page, int pageSize)
        {
            using (var context=new PersonallyContext())
            {
                var notes = context.Notes.AsQueryable(); //içinde sorgu yapılcak

                if (!string.IsNullOrEmpty(category))
                {
                    notes = notes.Include(x => x.noteCategories)
                        .ThenInclude(x => x.Category)
                        .Where(x => x.noteCategories.Any(a => a.Category.Title.ToLower() == category.ToLower()));
                }

                return notes.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }
        }

        public void Update(Note entity, int[] categoryIds)
        {
           using(var context=new PersonallyContext())
            {
                var note = context.Notes.Include(x => x.noteCategories)
                    .FirstOrDefault(x => x.Id == entity.Id);


                if(note!=null)
                {
                    note.Title = entity.Title;
                    note.Owner = entity.Owner;
                    note.ImageUrl = entity.ImageUrl;
                    note.IsDraft = entity.IsDraft;
                    note.noteCategories = categoryIds.Select(catid => new NoteCategory()
                    {
                        CategoryId=catid,
                        NoteId=entity.Id
                    }).ToList();

                    context.SaveChanges();
                        
                }
            }
        }
    }
}
