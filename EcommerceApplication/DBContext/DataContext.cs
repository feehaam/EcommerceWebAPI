using EcommerceApplication.Models.Products;
using EcommerceApplication.Models.Users;
using EcommerceApplication.Models.Orders;
using Microsoft.EntityFrameworkCore;
using EcommerceApplication.Models.Carts;

namespace EcommerceApplication.DBContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary keys
            modelBuilder.Entity<User>().HasKey(user => user.UserId);
            modelBuilder.Entity<Address>().HasKey(address => address.AddressId);
            modelBuilder.Entity<Contact>().HasKey(contact => contact.ContactId);

            modelBuilder.Entity<Product>().HasKey(product => product.ProductId);
            modelBuilder.Entity<Variant>().HasKey(variant => variant.VariantId);
            modelBuilder.Entity<Review>().HasKey(review => review.ReviewId);
            modelBuilder.Entity<Statistics>().HasKey(statistics => statistics.StatisticsId);

            modelBuilder.Entity<Order>().HasKey(order => order.OrderId);
            modelBuilder.Entity<OrderItems>().HasKey(oi => oi.OrderItemsId);

            modelBuilder.Entity<Cart>().HasKey(cart => cart.CartId);
            modelBuilder.Entity<CartItems>().HasKey(ci => ci.CartItemsId);

            // User relations
            modelBuilder.Entity<User>()
                .HasMany(user => user.Orders)
                .WithOne(order => order.User)
                .HasForeignKey(order => order.UserId);

            modelBuilder.Entity<User>()
                .HasOne(user => user.Address)
                .WithOne()
                .HasForeignKey<User>(adrs => adrs.UserId);

            modelBuilder.Entity<User>()
                .HasOne(user => user.Contacts)
                .WithOne(contact => contact.User)
                .HasForeignKey<Contact>(contact => contact.UserId);
            modelBuilder.Entity<Contact>()
                .HasOne(contact => contact.User)
                .WithOne(user => user.Contacts);

            modelBuilder.Entity<User>()
                .HasOne(user => user.Cart)
                .WithOne(cart => cart.User)
                .HasForeignKey<Cart>(cart => cart.UserId);

            // Product relations
            modelBuilder.Entity<Statistics>()
                .HasMany(stats => stats.Reviews)
                .WithOne(reviews => reviews.Statistics)
                .HasForeignKey(reviews => reviews.StatisticsId);
            modelBuilder.Entity<Review>()
                .HasOne(rev => rev.Statistics)
                .WithMany(stats => stats.Reviews)
                .HasForeignKey(rev => rev.StatisticsId);

            // Product relations
            modelBuilder.Entity<Product>()
                .HasOne(product => product.Statistics)
                .WithOne(stats => stats.Product);

            modelBuilder.Entity<Product>()
                .HasMany(product => product.Variants)
                .WithOne(variant => variant.Product)
                .HasForeignKey(variant => variant.ProductId);
            modelBuilder.Entity<Variant>()
                .HasOne(vari => vari.Product)
                .WithMany(product => product.Variants)
                .HasForeignKey(variant => variant.ProductId);


            // Order relations
            modelBuilder.Entity<Order>()
                .HasOne(order => order.User)
                .WithMany(user => user.Orders)
                .HasForeignKey(order => order.UserId);

            modelBuilder.Entity<Order>()
                .HasMany(order => order.Products)
                .WithOne(orderItems => orderItems.Order)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(order => order.PaymentStatus)
                .WithOne(ps => ps.Order);

            modelBuilder.Entity<PaymentStatus>()
                .HasOne(ps => ps.Order)
                .WithOne(order => order.PaymentStatus);

            // Cart relations
            modelBuilder.Entity<Cart>()
                .HasMany(cart => cart.Products)
                .WithOne()
                .HasForeignKey(ci => ci.CartId);

            // Payment relations
            modelBuilder.Entity<PaymentStatus>()
                .HasMany(ps => ps.Payments)
                .WithOne(payment => payment.PaymentStatus)
                .HasForeignKey(payment => payment.PaymentStatusId);
            modelBuilder.Entity<Payment>()
                .HasOne(payment => payment.PaymentStatus)
                .WithMany(ps => ps.Payments)
                .HasForeignKey(payment => payment.PaymentStatusId);
        }
    }
}
