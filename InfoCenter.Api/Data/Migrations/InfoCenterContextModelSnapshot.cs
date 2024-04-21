﻿// <auto-generated />
using System;
using InfoCenter.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InfoCenter.Api.Data.Migrations
{
    [DbContext(typeof(InfoCenterContext))]
    partial class InfoCenterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("InfoCenter.Api.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("SapNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<int>("UnitId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("SapNumber")
                        .IsUnique();

                    b.HasIndex("UnitId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("InfoCenter.Api.Models.ArticleDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContractId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("ContractId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("ArticleDetail");
                });

            modelBuilder.Entity("InfoCenter.Api.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContractNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("InfoCenter.Api.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("InfoCenter.Api.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Units");
                });

            modelBuilder.Entity("InfoCenter.Api.Models.Article", b =>
                {
                    b.HasOne("InfoCenter.Api.Models.Unit", "Unit")
                        .WithMany("Articles")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("InfoCenter.Api.Models.ArticleDetail", b =>
                {
                    b.HasOne("InfoCenter.Api.Models.Article", "Article")
                        .WithMany("ArticleDetails")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InfoCenter.Api.Models.Contract", "Contract")
                        .WithMany("ArticleDetails")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InfoCenter.Api.Models.Currency", "Currency")
                        .WithMany("ArticleDetails")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Contract");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("InfoCenter.Api.Models.Article", b =>
                {
                    b.Navigation("ArticleDetails");
                });

            modelBuilder.Entity("InfoCenter.Api.Models.Contract", b =>
                {
                    b.Navigation("ArticleDetails");
                });

            modelBuilder.Entity("InfoCenter.Api.Models.Currency", b =>
                {
                    b.Navigation("ArticleDetails");
                });

            modelBuilder.Entity("InfoCenter.Api.Models.Unit", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
