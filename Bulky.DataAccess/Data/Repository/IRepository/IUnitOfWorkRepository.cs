using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Bulky.DataAccess.Data;
using System.Linq;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IUnitOfWorkRepository
    {
        ICategoryRepository Category{ get;  }

        void Save();
    }
}
