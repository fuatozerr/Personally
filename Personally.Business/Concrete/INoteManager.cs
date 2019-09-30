using Personally.Business.Abstract;
using Personally.DataAccess.Abstract;
using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.Business.Concrete
{
    public class INoteManager : INoteService
    {
        private INoteDal _noteDal;
        public INoteManager(INoteDal noteDal)
        {
            _noteDal = noteDal;

        }
        public void Create(Note Entity)
        {
            _noteDal.Create(Entity);
        }

        public void Delete(Note Entity)
        {
            _noteDal.Delete(Entity);
        }

        public List<Note> GetAll()
        {
           return _noteDal.GetAll();
        }

        public Note GetById(int id)
        {
            return _noteDal.GetById(id);
        }

        public Note GetNoteDetail(int id)
        {
            return _noteDal.GetNoteDetail(id);
        }

        public void Update(Note Entity)
        {
            _noteDal.Update(Entity);
        }
    }
}
