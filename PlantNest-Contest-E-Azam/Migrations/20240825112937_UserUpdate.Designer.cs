﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlantNest_Contest_E_Azam.Models;

#nullable disable

namespace PlantNest_Contest_E_Azam.Migrations
{
    [DbContext(typeof(myContext))]
    [Migration("20240825112937_UserUpdate")]
    partial class UserUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlantNest_Contest_E_Azam.Models.Accessory", b =>
                {
                    b.Property<int>("accessory_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("accessory_id"));

                    b.Property<string>("accessory_image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("accessory_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("accessory_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("accessory_purpose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("accessory_id");

                    b.ToTable("tbl_accessory");
                });

            modelBuilder.Entity("PlantNest_Contest_E_Azam.Models.Admin", b =>
                {
                    b.Property<int>("admin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("admin_id"));

                    b.Property<string>("admin_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("admin_id");

                    b.ToTable("tbl_admin");
                });

            modelBuilder.Entity("PlantNest_Contest_E_Azam.Models.Cart", b =>
                {
                    b.Property<int>("cart_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cart_id"));

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("accessory_id")
                        .HasColumnType("int");

                    b.Property<string>("cart_status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("plant_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("cart_id");

                    b.HasIndex("plant_id");

                    b.HasIndex("user_id");

                    b.ToTable("tbl_cart");
                });

            modelBuilder.Entity("PlantNest_Contest_E_Azam.Models.Category", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("category_id"));

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("category_id");

                    b.ToTable("tbl_category");
                });

            modelBuilder.Entity("PlantNest_Contest_E_Azam.Models.Feedback", b =>
                {
                    b.Property<int>("feedback_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("feedback_id"));

                    b.Property<string>("user_message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("feedback_id");

                    b.ToTable("tbl_feedback");
                });

            modelBuilder.Entity("PlantNest_Contest_E_Azam.Models.Order", b =>
                {
                    b.Property<int>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("order_id"));

                    b.Property<int>("cart_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("order_date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("order_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("order_quantity")
                        .HasColumnType("int");

                    b.Property<string>("order_status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("order_id");

                    b.HasIndex("cart_id");

                    b.ToTable("tbl_order");
                });

            modelBuilder.Entity("PlantNest_Contest_E_Azam.Models.Plant", b =>
                {
                    b.Property<int>("plant_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("plant_id"));

                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.Property<string>("plant_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("plant_discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("plant_image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("plant_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("plant_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("plant_species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("plant_id");

                    b.HasIndex("category_id");

                    b.ToTable("tbl_plant");
                });

            modelBuilder.Entity("PlantNest_Contest_E_Azam.Models.Review", b =>
                {
                    b.Property<int>("review_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("review_id"));

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("accessory_id")
                        .HasColumnType("int");

                    b.Property<int?>("plant_id")
                        .HasColumnType("int");

                    b.Property<string>("review_comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("review_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("review_id");

                    b.HasIndex("accessory_id");

                    b.HasIndex("plant_id");

                    b.HasIndex("user_id");

                    b.ToTable("tbl_review");
                });

            modelBuilder.Entity("PlantNest_Contest_E_Azam.Models.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_id"));

                    b.Property<string>("user_contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("tbl_user");
                });

            modelBuilder.Entity("PlantNest_Contest_E_Azam.Models.Cart", b =>
                {
                    b.HasOne("PlantNest_Contest_E_Azam.Models.Plant", "plants")
                        .WithMany()
                        .HasForeignKey("plant_id");

                    b.HasOne("PlantNest_Contest_E_Azam.Models.User", "users")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plants");

                    b.Navigation("users");
                });

            modelBuilder.Entity("PlantNest_Contest_E_Azam.Models.Order", b =>
                {
                    b.HasOne("PlantNest_Contest_E_Azam.Models.Cart", "carts")
                        .WithMany()
                        .HasForeignKey("cart_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("carts");
                });

            modelBuilder.Entity("PlantNest_Contest_E_Azam.Models.Plant", b =>
                {
                    b.HasOne("PlantNest_Contest_E_Azam.Models.Category", "categories")
                        .WithMany("plants")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categories");
                });

            modelBuilder.Entity("PlantNest_Contest_E_Azam.Models.Review", b =>
                {
                    b.HasOne("PlantNest_Contest_E_Azam.Models.Accessory", "accessories")
                        .WithMany()
                        .HasForeignKey("accessory_id");

                    b.HasOne("PlantNest_Contest_E_Azam.Models.Plant", "plants")
                        .WithMany()
                        .HasForeignKey("plant_id");

                    b.HasOne("PlantNest_Contest_E_Azam.Models.User", "users")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("accessories");

                    b.Navigation("plants");

                    b.Navigation("users");
                });

            modelBuilder.Entity("PlantNest_Contest_E_Azam.Models.Category", b =>
                {
                    b.Navigation("plants");
                });
#pragma warning restore 612, 618
        }
    }
}
