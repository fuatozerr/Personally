using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.DataAccess.Abstract
{
    public interface INoteDal:IRepository<Note>
    {
        Note GetNoteDetails(int id);
        List<Note> GetAllNote();

    }
}
