using Personally.DataAccess.Abstract;
using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.DataAccess.Concrete
{
    public class EfCoreNoteDal : EfCoreGenericRepository<Note, PersonallyContext>, INoteDal
    {
        public List<Note> GetAllNote()
        {
            throw new NotImplementedException();
        }

        public Note GetNoteDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
