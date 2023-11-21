using BikeStoresEntidades;
using Microsoft.EntityFrameworkCore;

///<author> Ernestas Urbonas </author>
namespace EEFBikeStores;

public partial class BikeStoresContext : DbContext {
    public BikeStoresContext() {
    }

    public BikeStoresContext(DbContextOptions<BikeStoresContext> options)
        : base(options) {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BikeStores");

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Brand>(entity => {
            entity.HasKey(e => e.BrandId).HasName("PK__brands__5E5A8E271DE05FAB");
        });

        modelBuilder.Entity<Category>(entity => {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B4EA288CE2");
        });

        modelBuilder.Entity<Customer>(entity => {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB85588FE68F");
        });

        modelBuilder.Entity<Order>(entity => {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__465962290D7324E5");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__orders__customer__34C8D9D1");

            entity.HasOne(d => d.Staff).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orders__staff_id__36B12243");

            entity.HasOne(d => d.Store).WithMany(p => p.Orders).HasConstraintName("FK__orders__store_id__35BCFE0A");
        });

        modelBuilder.Entity<OrderItem>(entity => {
            entity.HasKey(e => new { e.OrderId, e.ItemId }).HasName("PK__order_it__837942D46FD59C39");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasConstraintName("FK__order_ite__order__3A81B327");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems).HasConstraintName("FK__order_ite__produ__3B75D760");
        });

        modelBuilder.Entity<Product>(entity => {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF5AA7DDD89");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products).HasConstraintName("FK__products__brand___29572725");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK__products__catego__286302EC");
        });

        modelBuilder.Entity<Staff>(entity => {
            entity.HasKey(e => e.StaffId).HasName("PK__staffs__1963DD9C2B7AD8D8");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager).HasConstraintName("FK__staffs__manager___31EC6D26");

            entity.HasOne(d => d.Store).WithMany(p => p.Staff).HasConstraintName("FK__staffs__store_id__30F848ED");
        });

        modelBuilder.Entity<Stock>(entity => {
            entity.HasKey(e => new { e.StoreId, e.ProductId }).HasName("PK__stocks__E68284D33A118CA5");

            entity.HasOne(d => d.Product).WithMany(p => p.Stocks).HasConstraintName("FK__stocks__product___3F466844");

            entity.HasOne(d => d.Store).WithMany(p => p.Stocks).HasConstraintName("FK__stocks__store_id__3E52440B");
        });

        modelBuilder.Entity<Store>(entity => {
            entity.HasKey(e => e.StoreId).HasName("PK__stores__A2F2A30C3DB2C6C0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
