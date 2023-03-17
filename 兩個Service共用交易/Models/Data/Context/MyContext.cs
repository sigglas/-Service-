using Microsoft.EntityFrameworkCore;
using 兩個Service共用交易.Models.EntityModel;

namespace 兩個Service共用交易.Models.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext() { }

        public MyContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<會員> 會員s { get; set; }
        public DbSet<帳號> 帳號s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<帳號>(entity =>
            {
                entity.ToTable("帳號");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.帳號名稱).HasMaxLength(100);
                entity.Property(e => e.密碼).HasMaxLength(300);
            });

            modelBuilder.Entity<會員>(entity =>
            {
                entity.ToTable("會員");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.姓名).HasMaxLength(20);
                entity.Property(e => e.推薦人).HasMaxLength(1).IsRequired();
            });
        }
    }
}
