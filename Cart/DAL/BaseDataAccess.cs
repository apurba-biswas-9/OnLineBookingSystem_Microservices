using Cart.Core;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.DAL
{
    public abstract class BaseDataAccess : IBaseDataAccess
    {
        protected CartContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }

        }

        protected void SetDbContext(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CartContext>();
            optionsBuilder.UseSqlServer(configuration.GetSection("ConnectionConfiguration:ConnectionString").Value);
            _context = new CartContext(optionsBuilder.Options, configuration);
        }

        public BaseDataAccess(CartContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> GetDBSet<TEntity>() where TEntity : class, IEntity
        {
            return this._context.Set<TEntity>();
        }

        protected void AddRange<TEntity>(IList<TEntity> list) where TEntity : class, IEntity
        {
            _context.AddRange(list);           
        }

        public void UpdateRange<TEntity>(IList<TEntity> list) where TEntity : class, IEntity
        {
            _context.UpdateRange(list);         
        }



    }
}
