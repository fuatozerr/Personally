using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.Business.Abstract
{
    public interface INoteService
    {
        Note GetById(int id);
        List<Note> GetAll();
        Note GetNoteDetail(int id);
        void Create(Note Entity);
        void Update(Note Entity);

        void Delete(Note Entity);

        List<Note> GetNotesByCategory(int? id,int page,int pageSize);


    }
}
