using System;
using System.Threading;
using System.Threading.Tasks;
using Cart.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cart.DAL
{
    public partial class CartContext : DbContext, IUnitOfWork
    {
       
        public virtual DbSet<Cart> Cart { get; set; }

        private readonly IConfiguration _configuration;

        public CartContext(DbContextOptions<CartContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetSection("ConnectionConfiguration:ConnectionString").Value);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
