using DYLHS5_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DYLHS5_HFT_2021221.Data
{
    public class XYZDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public XYZDbContext()
        {
            Database.EnsureCreated();
        }

        public XYZDbContext(DbContextOptions<XYZDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

            }


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //PRODUCTS
            Product dorko1 = new Product() { ProductId = 1, ProductName = "BOUNCE", Color = "BROWN", Size = 41, Price = 24999 };
            Product dorko2 = new Product() { ProductId = 2, ProductName = "CARBONITE", Color = "BLACK", Size = 42, Price = 24999 };

            Product adidas1 = new Product() { ProductId = 3, ProductName = "ORIGINALS CONTINENTAL 80 STRIPES", Color = "BLACK", Size = 42, Price = 29999 };
            Product adidas2 = new Product() { ProductId = 4, ProductName = "PERFORMANCE HOOPS MID 2.0 K", Color = "BLACK", Size = 40, Price = 14999 };

            Product nike1 = new Product() { ProductId = 5, ProductName = "AIR PRESTO", Color = "ORANGE", Size = 40, Price = 44999 };
            Product nike2 = new Product() { ProductId = 6, ProductName = "REVOLUTION 5", Color = "GREY", Size = 45, Price = 19999 };

            Product converse1 = new Product() { ProductId = 7, ProductName = "RIVAL", Color = "GREY", Size = 41, Price = 24999 };
            Product converse2 = new Product() { ProductId = 8, ProductName = "COURTLANDT", Color = "GREY", Size = 44, Price = 9999 };

            Product vans1 = new Product() { ProductId = 9, ProductName = "OLD SKOOL", Color = "BLUE", Size = 41, Price = 29999 };
            Product vans2 = new Product() { ProductId = 10, ProductName = "ULTRARANGE EXO", Color = "BLACK", Size = 40, Price = 39999 };

            //CUSTOMERS
            Customer customer1 = new Customer() { CustomerId = 1, CustomerName = "A.Aladár", Address = "Randomcím1", PhoneNumber = 06701234567 };
            Customer customer2 = new Customer() { CustomerId = 2, CustomerName = "B.Bence", PhoneNumber = 06701234568 };
            Customer customer3 = new Customer() { CustomerId = 3, CustomerName = "C.Cecília", PhoneNumber = 06701234569, Address = "Randomcim2" };
            Customer customer4 = new Customer() { CustomerId = 4, CustomerName = "D.Dávid", PhoneNumber = 06701234570 };
            Customer customer5 = new Customer() { CustomerId = 5, CustomerName = "E.Elvira", PhoneNumber = 06701234571 };

            //ORDERS
            Order order1 = new Order() { OrderId = 1, ProductId = dorko1.ProductId, CustomerId = customer1.CustomerId, IsPrePaid = true, IsTransportRequired = false };
            Order order2 = new Order() { OrderId = 2, ProductId = dorko2.ProductId, CustomerId = customer2.CustomerId, IsPrePaid = false, IsTransportRequired = true };
            Order order3 = new Order() { OrderId = 3, ProductId = adidas1.ProductId, CustomerId = customer1.CustomerId, IsPrePaid = true, IsTransportRequired = false };
            Order order4 = new Order() { OrderId = 4, ProductId = adidas2.ProductId, CustomerId = customer2.CustomerId, IsPrePaid = true, IsTransportRequired = true };
            Order order5 = new Order() { OrderId = 5, ProductId = nike1.ProductId, CustomerId = customer3.CustomerId, IsPrePaid = false, IsTransportRequired = false };
            Order order6 = new Order() { OrderId = 6, ProductId = nike2.ProductId, CustomerId = customer4.CustomerId, IsPrePaid = true, IsTransportRequired = false };
            Order order7 = new Order() { OrderId = 7, ProductId = converse1.ProductId, CustomerId = customer3.CustomerId, IsPrePaid = false, IsTransportRequired = false };
            Order order8 = new Order() { OrderId = 8, ProductId = converse2.ProductId, CustomerId = customer4.CustomerId, IsPrePaid = true, IsTransportRequired = true };
            Order order9 = new Order() { OrderId = 9, ProductId = vans1.ProductId, CustomerId = customer5.CustomerId, IsPrePaid = true, IsTransportRequired = true };
            Order order10 = new Order() { OrderId = 10, ProductId = vans2.ProductId, CustomerId = customer5.CustomerId, IsPrePaid = true, IsTransportRequired = true };

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasMany(product => product.Orders)
                .WithOne(order => order.Product)
                .HasForeignKey(product => product.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasMany(customer => customer.Orders)
                .WithOne(order => order.Customer)
                .HasForeignKey(customer => customer.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(order => order.Customer)
                .WithMany(customer => customer.Orders)
                .HasForeignKey(customer => customer.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(order => order.Product)
                .WithMany(product => product.Orders)
                .HasForeignKey(order => order.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            });


            
            modelBuilder.Entity<Product>().HasData(dorko1,dorko2, nike1, nike2, adidas1, adidas2, converse1, converse2, vans1, vans2);
            modelBuilder.Entity<Customer>().HasData(customer1, customer2, customer3, customer4, customer5);
            modelBuilder.Entity<Order>().HasData(order1,order2,order3,order4,order5,order6,order7,order8,order9,order10);
        }
    }
}
