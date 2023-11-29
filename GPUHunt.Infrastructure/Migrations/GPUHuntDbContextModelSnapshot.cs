﻿// <auto-generated />
using System;
using GPUHunt.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GPUHunt.Infrastructure.Migrations
{
    [DbContext(typeof(GPUHuntDbContext))]
    partial class GPUHuntDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GPUHunt.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("GPUHunt.Domain.Entities.GraphicCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubvendorId")
                        .HasColumnType("int");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("SubvendorId");

                    b.HasIndex("VendorId");

                    b.ToTable("GraphicCards");
                });

            modelBuilder.Entity("GPUHunt.Domain.Entities.Prices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CrawlTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("GraphicCardId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPriceEqual")
                        .HasColumnType("bit");

                    b.Property<decimal?>("MoreleActualPrice")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.Property<decimal?>("MoreleHighestPriceEver")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.Property<DateTime?>("MoreleHighestPriceEverCrawlDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("MoreleLowestPriceEver")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.Property<DateTime?>("MoreleLowestPriceEverCrawlDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("XKomActualPrice")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.Property<decimal?>("XkomHighestPriceEver")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.Property<DateTime?>("XkomHighestPriceEverCrawlDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("XkomLowestPriceEver")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.Property<DateTime?>("XkomLowestPriceEverCrawlDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GraphicCardId")
                        .IsUnique();

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("GPUHunt.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GPUHunt.Domain.Entities.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("GPUHunt.Domain.Entities.Subvendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subvendors");
                });

            modelBuilder.Entity("GPUHunt.Domain.Entities.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("GPUHunt.Domain.Entities.Account", b =>
                {
                    b.HasOne("GPUHunt.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GPUHunt.Domain.Entities.GraphicCard", b =>
                {
                    b.HasOne("GPUHunt.Domain.Entities.Account", null)
                        .WithMany("FavoritesGraphicCards")
                        .HasForeignKey("AccountId");

                    b.HasOne("GPUHunt.Domain.Entities.Subvendor", "Subvendor")
                        .WithMany("GraphicCards")
                        .HasForeignKey("SubvendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GPUHunt.Domain.Entities.Vendor", "Vendor")
                        .WithMany("GraphicCards")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subvendor");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("GPUHunt.Domain.Entities.Prices", b =>
                {
                    b.HasOne("GPUHunt.Domain.Entities.GraphicCard", "GraphicCard")
                        .WithOne("Prices")
                        .HasForeignKey("GPUHunt.Domain.Entities.Prices", "GraphicCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GraphicCard");
                });

            modelBuilder.Entity("GPUHunt.Domain.Entities.Account", b =>
                {
                    b.Navigation("FavoritesGraphicCards");
                });

            modelBuilder.Entity("GPUHunt.Domain.Entities.GraphicCard", b =>
                {
                    b.Navigation("Prices")
                        .IsRequired();
                });

            modelBuilder.Entity("GPUHunt.Domain.Entities.Subvendor", b =>
                {
                    b.Navigation("GraphicCards");
                });

            modelBuilder.Entity("GPUHunt.Domain.Entities.Vendor", b =>
                {
                    b.Navigation("GraphicCards");
                });
#pragma warning restore 612, 618
        }
    }
}
