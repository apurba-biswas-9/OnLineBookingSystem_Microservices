using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Core
{
    public interface IBaseDataAccess
    {
        DbSet<TEntity> GetDBSet<TEntity>() where TEntity : class, IEntity;
    }
}
