using Microsoft.EntityFrameworkCore;

namespace DALEF.Models
{
    public partial class R2024Context : DbContext
    {
        public R2024Context()
        { }
        public R2024Context(DbContextOptions<R2024Context> options)
            : base(options)
        { }
        public virtual DbSet<TblManagers> Managerss { get; set; }
        public virtual DbSet<TblGoods> Goods { get; set; }
        public virtual DbSet<TblShipping> Shippings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("TradingCompany");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblManagers>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("employees");

                entity.Property(e => e.last_Name).HasMaxLength(50);

            });
            modelBuilder.Entity<TblGoods>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("goods");

                entity.HasOne(d => d.Managers)
                .WithMany(p => p.Goods)
                .HasForeignKey(d => d.manager_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblGoods_tblManagers");
            });
            modelBuilder.Entity<TblShipping>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("shipping");

                entity.HasOne(d => d.Goods)
                .WithMany(p => p.TblShippings)
                .HasForeignKey(d => d.goods_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblShipping_tblGoods");

                entity.Property(e => e.status).HasDefaultValue("Waiting for approve");

                entity.Property(e => e.destination_date).HasDefaultValue(DateTimeOffset.Now.AddDays(1));

            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
