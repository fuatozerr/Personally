﻿using Personally.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personally.DataAccess.Abstract
{
    public interface ICategoryDal
    {
        Category GetByIdWithProducts(int id);

    }
}
