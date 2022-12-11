﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Replica.Persistence;

#nullable disable

namespace Replica.Persistence.Migrations
{
    [DbContext(typeof(ReplicaDbContext))]
    [Migration("20221211105000_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Replica.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Replica.Domain.Entities.ComponentCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ComponentCategories");
                });

            modelBuilder.Entity("Replica.Domain.Entities.GameZone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatingCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GameZones");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Hookah", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AdditionalHose")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Hookahs");
                });

            modelBuilder.Entity("Replica.Domain.Entities.HookahComponent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("HookahId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("HookahId");

                    b.ToTable("HookahComponents");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Accepted")
                        .HasColumnType("bit");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("GameZoneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<Guid?>("TableId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameZoneId");

                    b.HasIndex("TableId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("SubcategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Replica.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6fa17fba-626d-481c-81cd-bbda29109fab"),
                            Description = "The main user of the system, with all access rights.",
                            Name = "admin"
                        },
                        new
                        {
                            Id = new Guid("2bb5984d-3ff9-49c3-9e54-5dcff385fb98"),
                            Description = "The management staff of the lounge bar.",
                            Name = "manager"
                        },
                        new
                        {
                            Id = new Guid("0ba5721c-bf18-47f9-be9d-f0f1eb69434a"),
                            Description = "Responsible for the bar.",
                            Name = "barman"
                        },
                        new
                        {
                            Id = new Guid("2f9d9d3f-a8f3-4916-a904-5d325bac45ec"),
                            Description = "Responsible for preparing hookah orders.",
                            Name = "hookah-waiter"
                        },
                        new
                        {
                            Id = new Guid("e4821f82-1182-4bf1-a74a-d390d2c040d6"),
                            Description = "Staff who form orders and serve meals to visitors.",
                            Name = "waiter"
                        },
                        new
                        {
                            Id = new Guid("1057c418-d34a-46ea-9e7b-b1dffd462a05"),
                            Description = "An ordinary user of the system, a client.",
                            Name = "user"
                        });
                });

            modelBuilder.Entity("Replica.Domain.Entities.Subcategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategories");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Table", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatingCapacity")
                        .HasColumnType("int");

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("Replica.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("*/Image/User/default-user-image.jpg");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4e6d597-950b-4d87-b568-9ce087f3c79f"),
                            Email = "admin@replica.com",
                            FirstName = "Admin",
                            Image = "*/Image/User/default-user-image.jpg",
                            LastName = "Replica",
                            Nickname = "Reeditor",
                            Password = "admin",
                            Phone = "0975440309",
                            RoleId = new Guid("6fa17fba-626d-481c-81cd-bbda29109fab")
                        });
                });

            modelBuilder.Entity("Replica.Domain.Entities.Hookah", b =>
                {
                    b.HasOne("Replica.Domain.Entities.Order", null)
                        .WithMany("Hookahs")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Replica.Domain.Entities.HookahComponent", b =>
                {
                    b.HasOne("Replica.Domain.Entities.ComponentCategory", "Category")
                        .WithMany("Components")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Replica.Domain.Entities.Hookah", null)
                        .WithMany("Components")
                        .HasForeignKey("HookahId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Order", b =>
                {
                    b.HasOne("Replica.Domain.Entities.GameZone", "GameZone")
                        .WithMany()
                        .HasForeignKey("GameZoneId");

                    b.HasOne("Replica.Domain.Entities.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId");

                    b.HasOne("Replica.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameZone");

                    b.Navigation("Table");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Product", b =>
                {
                    b.HasOne("Replica.Domain.Entities.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");

                    b.HasOne("Replica.Domain.Entities.Subcategory", "Subcategory")
                        .WithMany("Products")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("Replica.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Replica.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Subcategory", b =>
                {
                    b.HasOne("Replica.Domain.Entities.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Replica.Domain.Entities.User", b =>
                {
                    b.HasOne("Replica.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Category", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("Replica.Domain.Entities.ComponentCategory", b =>
                {
                    b.Navigation("Components");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Hookah", b =>
                {
                    b.Navigation("Components");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Order", b =>
                {
                    b.Navigation("Hookahs");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Replica.Domain.Entities.Subcategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Replica.Domain.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}