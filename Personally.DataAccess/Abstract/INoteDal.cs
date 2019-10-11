using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.DataAccess.Abstract
{
    public interface INoteDal:IRepository<Note>
    {
        //Note GetNoteDetails(int id);
        List<Note> GetAllNote();

        Note GetNoteDetail(int id);

        List<Note> GetNotesByCategory(string category, int page, int pageSize);
        int GetCounByCategory(string category);
        Note GetByIdWithCategories(int id);
        void Update(Note entity, int[] categoryIds);
        void CreteNoteWithCategory(Note entity, int[] categoryIds);
    }
}
