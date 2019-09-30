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
        public List<Category> GetAllCategories()
        {
            using (var context = new PersonallyContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetByIdWithProducts(int id)
        {
            throw new NotImplementedException();
        }
    }
}
