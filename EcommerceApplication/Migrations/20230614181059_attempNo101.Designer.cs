﻿// <auto-generated />
using System;
using EcommerceApplication.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcommerceApplication.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230614181059_attempNo101")]
    partial class attempNo101
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcommerceApplication.Models.Carts.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Carts.CartItems", b =>
                {
                    b.Property<int>("CartItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartItemsId"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartItemsId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Orders.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("CustomerPhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeliveryAddressAddressId")
                        .HasColumnType("int");

                    b.Property<double>("DeliveryCharge")
                        .HasColumnType("float");

                    b.Property<string>("DeliveryStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeliveryTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PlacementTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("ProductsCost")
                        .HasColumnType("float");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("VoucherReduction")
                        .HasColumnType("float");

                    b.HasKey("OrderId");

                    b.HasIndex("DeliveryAddressAddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Orders.OrderItems", b =>
                {
                    b.Property<int>("OrderItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemsId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemsId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Orders.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("PaymentStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.HasIndex("PaymentStatusId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Orders.PaymentStatus", b =>
                {
                    b.Property<int>("PaymentStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentStatusId"));

                    b.Property<byte>("CompletedPayment")
                        .HasColumnType("tinyint");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("PaymentStatusId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("PaymentStatuses");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotosURL1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotosURL2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotosURL3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.ProductTag", b =>
                {
                    b.Property<int>("ProductTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductTagId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductTagId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductTags");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DownVote")
                        .HasColumnType("int");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<int>("StatisticsId")
                        .HasColumnType("int");

                    b.Property<int>("UpVote")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewId");

                    b.HasIndex("StatisticsId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.Statistics", b =>
                {
                    b.Property<int>("StatisticsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatisticsId"));

                    b.Property<int>("Favorites")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<double>("ReviewScore")
                        .HasColumnType("float");

                    b.Property<int>("SellCount")
                        .HasColumnType("int");

                    b.HasKey("StatisticsId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.Variant", b =>
                {
                    b.Property<int>("VariantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VariantId"));

                    b.Property<string>("PhotoURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VariantId");

                    b.HasIndex("ProductId");

                    b.ToTable("Variant");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Users.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetHomeOther")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Users.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"));

                    b.Property<string>("Optional1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Optional2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Primary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ContactId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Users.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Carts.Cart", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Users.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("EcommerceApplication.Models.Carts.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Carts.CartItems", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Carts.Cart", null)
                        .WithMany("Products")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceApplication.Models.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Orders.Order", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Users.Address", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressAddressId");

                    b.HasOne("EcommerceApplication.Models.Users.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryAddress");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Orders.OrderItems", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Orders.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceApplication.Models.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Orders.Payment", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Orders.PaymentStatus", "PaymentStatus")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentStatus");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Orders.PaymentStatus", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Orders.Order", "Order")
                        .WithOne("PaymentStatus")
                        .HasForeignKey("EcommerceApplication.Models.Orders.PaymentStatus", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.Product", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Products.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.ProductTag", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Products.Product", "Product")
                        .WithMany("Tags")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.Review", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Products.Statistics", "Statistics")
                        .WithMany("Reviews")
                        .HasForeignKey("StatisticsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.Statistics", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Products.Product", "Product")
                        .WithOne("Statistics")
                        .HasForeignKey("EcommerceApplication.Models.Products.Statistics", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.Tag", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Products.Category", null)
                        .WithMany("Tags")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.Variant", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Products.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Users.Contact", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Users.User", "User")
                        .WithOne("Contacts")
                        .HasForeignKey("EcommerceApplication.Models.Users.Contact", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Users.User", b =>
                {
                    b.HasOne("EcommerceApplication.Models.Users.Address", "Address")
                        .WithOne()
                        .HasForeignKey("EcommerceApplication.Models.Users.User", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Carts.Cart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Orders.Order", b =>
                {
                    b.Navigation("PaymentStatus");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Orders.PaymentStatus", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.Category", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.Product", b =>
                {
                    b.Navigation("Statistics");

                    b.Navigation("Tags");

                    b.Navigation("Variants");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Products.Statistics", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("EcommerceApplication.Models.Users.User", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("Contacts");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
