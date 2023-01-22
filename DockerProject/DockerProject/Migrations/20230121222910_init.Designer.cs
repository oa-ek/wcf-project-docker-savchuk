﻿// <auto-generated />
using DockerProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DockerProject.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230121222910_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

            modelBuilder.Entity("DockerProject.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lenovo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Xiaomi"
                        });
                });

            modelBuilder.Entity("DockerProject.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 2,
                            Price = 15000,
                            Title = "Galaxy M51"
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 2,
                            Price = 17500,
                            Title = "Galaxy A51"
                        },
                        new
                        {
                            Id = 3,
                            CompanyId = 3,
                            Price = 19000,
                            Title = "Iphone X"
                        });
                });

            modelBuilder.Entity("DockerProject.Models.Phone", b =>
                {
                    b.HasOne("DockerProject.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}
