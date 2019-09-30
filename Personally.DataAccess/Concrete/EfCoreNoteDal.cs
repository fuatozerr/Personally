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
        public List<Note> GetNotesByCategory(int? id, int page, int pageSize)
        {
            using (var context=new PersonallyContext())
            {
                var notes = context.Notes.AsQueryable(); //içinde sorgu yapılcak

                if(id!=null)
                {
                    notes = notes.Include(x => x.noteCategories)
                        .ThenInclude(x => x.Category)
                        .Where(x => x.noteCategories.Any(i=>i.Category.Id==id));
                }

                return notes.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }
        }
    }
}
