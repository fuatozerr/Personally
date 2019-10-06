using Personally.Business.Abstract;
using Personally.DataAccess.Abstract;
using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.Business.Concrete
{
    public class ICategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public ICategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Create(Category entity)
        {
            _categoryDal.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public void DeleteFromCategory(int categoryId, int noteId)
        {
            _categoryDal.DeleteFromCategory(categoryId, noteId);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryDal.GetAllCategories();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public Category GetByWithNotes(int id)
        {
            return _categoryDal.GetByWithNotes(id);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
