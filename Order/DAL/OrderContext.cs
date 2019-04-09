using System;
using System.Threading;
using System.Threading.Tasks;
using Order.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Order.DAL
{
    public partial class OrderContext : DbContext, IUnitOfWork
    {
        public virtual DbSet<OrderHistory> OrderHistory { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        private readonly IConfiguration _configuration;

        public OrderContext(DbContextOptions<OrderContext> options, IConfiguration configuration)
           : base(options)
        {
            _configuration = configuration;
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
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
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderHistory)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OorderHistory_Order");
            });
        }
    }
}
