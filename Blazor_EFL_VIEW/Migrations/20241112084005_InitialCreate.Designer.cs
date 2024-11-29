﻿// <auto-generated />
using System;
using Blazor_EFL_VIEW.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pomelo.EntityFrameworkCore.MySql;

#nullable disable

namespace EntityFramework_Library.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241112084005_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EntityFramework_Library.Classes.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("AvailableCopies")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ItemType")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("varchar(21)");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("ItemType").HasValue("Item");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EntityFramework_Library.Classes.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PersonType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("PersonType").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EntityFramework_Library.Classes.Biography", b =>
                {
                    b.HasBaseType("EntityFramework_Library.Classes.Item");

                    b.HasDiscriminator().HasValue("Biography");
                });

            modelBuilder.Entity("EntityFramework_Library.Classes.Fantasy", b =>
                {
                    b.HasBaseType("EntityFramework_Library.Classes.Item");

                    b.HasDiscriminator().HasValue("Fantasy");
                });

            modelBuilder.Entity("EntityFramework_Library.Classes.Mystery", b =>
                {
                    b.HasBaseType("EntityFramework_Library.Classes.Item");

                    b.HasDiscriminator().HasValue("Mystery");
                });

            modelBuilder.Entity("EntityFramework_Library.Classes.NonFiction", b =>
                {
                    b.HasBaseType("EntityFramework_Library.Classes.Item");

                    b.HasDiscriminator().HasValue("NonFiction");
                });

            modelBuilder.Entity("EntityFramework_Library.Classes.Novel", b =>
                {
                    b.HasBaseType("EntityFramework_Library.Classes.Item");

                    b.HasDiscriminator().HasValue("Novel");
                });

            modelBuilder.Entity("EntityFramework_Library.Classes.ScienceFiction", b =>
                {
                    b.HasBaseType("EntityFramework_Library.Classes.Item");

                    b.HasDiscriminator().HasValue("ScienceFiction");
                });

            modelBuilder.Entity("EntityFramework_Library.Classes.Textbook", b =>
                {
                    b.HasBaseType("EntityFramework_Library.Classes.Item");

                    b.HasDiscriminator().HasValue("Textbook");
                });

            modelBuilder.Entity("EntityFramework_Library.Classes.Author", b =>
                {
                    b.HasBaseType("EntityFramework_Library.Classes.Person");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Author");
                });

            modelBuilder.Entity("EntityFramework_Library.Classes.Customer", b =>
                {
                    b.HasBaseType("EntityFramework_Library.Classes.Person");

                    b.Property<DateTime>("MembershipDate")
                        .HasColumnType("datetime(6)");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("EntityFramework_Library.Classes.Librarian", b =>
                {
                    b.HasBaseType("EntityFramework_Library.Classes.Person");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Librarian");
                });
#pragma warning restore 612, 618
        }
    }
}
