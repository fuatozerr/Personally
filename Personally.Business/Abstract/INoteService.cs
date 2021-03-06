﻿using Personally.Entities;
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

        List<Note> GetNotesByCategory(string category,int page,int pageSize);
        int GetCounByCategory(string category);

        Note GetByIdWithCategories(int id);
        void Update(Note entity, int[] categoryIds);
        void CreteNoteWithCategory(Note entity, int[] categoryIds);
    }
}
