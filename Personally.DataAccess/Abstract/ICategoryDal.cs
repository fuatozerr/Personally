using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.DataAccess.Abstract
{
    public interface ICategoryDal:IRepository<Category>
    {
        List<Category> GetAllCategories();
        Category GetByWithNotes(int id);
        void DeleteFromCategory(int categoryId, int noteId);
    }
}
