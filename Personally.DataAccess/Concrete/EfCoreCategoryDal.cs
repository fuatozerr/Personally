using Personally.DataAccess.Abstract;
using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.DataAccess.Concrete
{
    public class EfCoreCategoryDal : EfCoreGenericRepository<Category, PersonallyContext>, ICategoryDal
    {
        public Category GetByIdWithProducts(int id)
        {
            throw new NotImplementedException();
        }
    }
}
