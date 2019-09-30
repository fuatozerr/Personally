using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);

    }
}
