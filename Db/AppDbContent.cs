using Shop_Project.Models;
using Microsoft.EntityFrameworkCore;


namespace Shop_Project.Db
    {
    public class AppDbContent : DbContext
        {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder
               .Entity<Product>()
               .HasMany(c => c.Orders)
               .WithMany(s => s.Products)
               .UsingEntity<Enrollment>(
                  j => j


                   .HasOne(pt => pt.Order)
                   .WithMany(t => t.Enrollments)
                   .HasForeignKey(pt => pt.OrderId),

               j => j
                   .HasOne(pt => pt.Product)
                   .WithMany(p => p.Enrollments)
                   .HasForeignKey(pt => pt.ProductId),
               j =>
               {

                   j.Property(pt => pt.Count).HasDefaultValue(3);
                   j.HasKey(t => new { t.OrderId, t.ProductId });
                   j.ToTable("Enrollments");
               });

            } 




        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
            {


       
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shop_Project.Models.Enrollment> Enrollment { get; set; } = default!;
   

        }
    }
