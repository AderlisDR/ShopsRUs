﻿// <auto-generated />
using System;
using Boundaries.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Boundaries.Persistence.Migrations
{
    [DbContext(typeof(DefaultContext))]
    partial class DefaultContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("Core.Entities.BillDiscount", b =>
                {
                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.HasKey("BillId", "DiscountId");

                    b.HasIndex("DiscountId");

                    b.ToTable("BillDiscount");
                });

            modelBuilder.Entity("Core.Entities.BillItem", b =>
                {
                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotalAmount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("BillId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("BillItem");
                });

            modelBuilder.Entity("Core.Entities.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("DiscountType")
                        .HasColumnType("int");

                    b.Property<int>("DiscountTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountValue")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Discount");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOnUtc = new DateTime(2021, 5, 8, 18, 10, 1, 566, DateTimeKind.Local).AddTicks(5512),
                            Description = "10% de descuento para clientes afiliados",
                            DiscountType = 1,
                            DiscountTypeId = 1,
                            DiscountValue = 10.00m,
                            Name = "10% Afiliados"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOnUtc = new DateTime(2021, 5, 8, 18, 10, 1, 567, DateTimeKind.Local).AddTicks(3355),
                            Description = "30% de descuento para empleados",
                            DiscountType = 1,
                            DiscountTypeId = 1,
                            DiscountValue = 30.00m,
                            Name = "30% Empleados"
                        },
                        new
                        {
                            Id = 3,
                            CreatedOnUtc = new DateTime(2021, 5, 8, 18, 10, 1, 567, DateTimeKind.Local).AddTicks(3367),
                            Description = "10% de descuento para clientes afiliados",
                            DiscountType = 1,
                            DiscountTypeId = 1,
                            DiscountValue = 10.00m,
                            Name = "5% 2 años con nosotros"
                        });
                });

            modelBuilder.Entity("Core.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOnUtc = new DateTime(2021, 5, 8, 22, 10, 1, 559, DateTimeKind.Utc).AddTicks(8398),
                            Name = "Manzana",
                            TypeId = 1,
                            UnitPrice = 24.99m
                        },
                        new
                        {
                            Id = 2,
                            CreatedOnUtc = new DateTime(2021, 5, 8, 22, 10, 1, 559, DateTimeKind.Utc).AddTicks(8465),
                            Name = "Pantalon",
                            TypeId = 3,
                            UnitPrice = 299.99m
                        },
                        new
                        {
                            Id = 3,
                            CreatedOnUtc = new DateTime(2021, 5, 8, 22, 10, 1, 559, DateTimeKind.Utc).AddTicks(8468),
                            Name = "Mistolin",
                            TypeId = 2,
                            UnitPrice = 84.99m
                        });
                });

            modelBuilder.Entity("Core.Entities.ItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("ItemType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOnUtc = new DateTime(2021, 5, 8, 22, 10, 1, 558, DateTimeKind.Utc).AddTicks(953),
                            Name = "Comestible"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOnUtc = new DateTime(2021, 5, 8, 22, 10, 1, 558, DateTimeKind.Utc).AddTicks(1015),
                            Name = "Limpieza"
                        },
                        new
                        {
                            Id = 3,
                            CreatedOnUtc = new DateTime(2021, 5, 8, 22, 10, 1, 558, DateTimeKind.Utc).AddTicks(1016),
                            Name = "Ropa"
                        });
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AffiliatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAffiliated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEmployee")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AffiliatedOnUtc = new DateTime(2021, 5, 8, 22, 10, 1, 548, DateTimeKind.Utc).AddTicks(7018),
                            CreatedOnUtc = new DateTime(2021, 5, 8, 22, 10, 1, 548, DateTimeKind.Utc).AddTicks(7670),
                            IsAffiliated = true,
                            IsEmployee = false,
                            Name = "Juan Pérez"
                        },
                        new
                        {
                            Id = 2,
                            AffiliatedOnUtc = new DateTime(2021, 5, 8, 22, 10, 1, 548, DateTimeKind.Utc).AddTicks(8217),
                            CreatedOnUtc = new DateTime(2021, 5, 8, 22, 10, 1, 548, DateTimeKind.Utc).AddTicks(8229),
                            IsAffiliated = true,
                            IsEmployee = true,
                            Name = "María Magdalena"
                        },
                        new
                        {
                            Id = 3,
                            AffiliatedOnUtc = new DateTime(2021, 5, 8, 22, 10, 1, 548, DateTimeKind.Utc).AddTicks(8237),
                            CreatedOnUtc = new DateTime(2021, 5, 8, 22, 10, 1, 548, DateTimeKind.Utc).AddTicks(8238),
                            IsAffiliated = false,
                            IsEmployee = false,
                            Name = "Pedro Almonte"
                        });
                });

            modelBuilder.Entity("Core.Entities.Bill", b =>
                {
                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("Bills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.BillDiscount", b =>
                {
                    b.HasOne("Core.Entities.Discount", "Discount")
                        .WithMany("Bills")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Bill", "Bill")
                        .WithMany("Discounts")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.BillItem", b =>
                {
                    b.HasOne("Core.Entities.Item", "Item")
                        .WithMany("Bills")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Bill", "Bill")
                        .WithMany("Items")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Item", b =>
                {
                    b.HasOne("Core.Entities.ItemType", "Type")
                        .WithMany("Items")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
