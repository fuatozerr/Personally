using Microsoft.EntityFrameworkCore;
using Personally.DataAccess.Abstract;
using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Personally.DataAccess.Concrete
{
    public class EfCoreCategoryDal : EfCoreGenericRepository<Category, PersonallyContext>, ICategoryDal

    {
        public void DeleteFromCategory(int categoryId, int noteId)
        {
           using(var context=new PersonallyContext())
            {
                var cmd = @"delete from NoteCategory where NoteId=@p0 And CategoryId=@p1";
                context.Database.ExecuteSqlCommand(cmd, noteId, categoryId);
            }
        }

        public List<Category> GetAllCategories()
        {
            using (var context = new PersonallyContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetByWithNotes(int id)
        {
            using (var context=new PersonallyContext())
            {
                return context.Categories
                    .Where(x => x.Id == id)
                    .Include(x => x.noteCategories)
                    .ThenInclude(x => x.Note).FirstOrDefault();
            }
        }

       
    }
}
