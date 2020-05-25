﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200116103756_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CFirstName");

                    b.Property<string>("CName");

                    b.HasKey("CId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PName")
                        .IsRequired();

                    b.Property<decimal>("PPrice");

                    b.HasKey("PId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Models.ShoppingBag", b =>
                {
                    b.Property<int>("SBId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CId");

                    b.Property<DateTime>("SBDate");

                    b.Property<int?>("SIId");

                    b.HasKey("SBId");

                    b.HasIndex("CId");

                    b.ToTable("ShoppingBags");
                });

            modelBuilder.Entity("Models.ShoppingItem", b =>
                {
                    b.Property<int>("SIId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PId");

                    b.Property<int>("Quantity");

                    b.Property<int>("SBId");

                    b.HasKey("SIId");

                    b.HasIndex("PId");

                    b.HasIndex("SBId");

                    b.ToTable("ShoppingItems");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.ShoppingBag", b =>
                {
                    b.HasOne("Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.ShoppingItem", b =>
                {
                    b.HasOne("Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.ShoppingBag", "ShoppingBag")
                        .WithMany("ShoppingItems")
                        .HasForeignKey("SBId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
