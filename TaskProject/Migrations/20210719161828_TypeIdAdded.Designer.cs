﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskProject.Models.EF;

namespace TaskProject.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210719161828_TypeIdAdded")]
    partial class TypeIdAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskProject.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(2021, 7, 19, 19, 18, 28, 370, DateTimeKind.Local).AddTicks(8026),
                            Title = "First Task",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedTime = new DateTime(2021, 7, 19, 19, 18, 28, 372, DateTimeKind.Local).AddTicks(278),
                            Title = "Second Task",
                            TypeId = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedTime = new DateTime(2021, 7, 19, 19, 18, 28, 372, DateTimeKind.Local).AddTicks(333),
                            Title = "Third Task",
                            TypeId = 3
                        });
                });

            modelBuilder.Entity("TaskProject.Models.TaskType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaskTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Task"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Bug"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Change Request"
                        });
                });

            modelBuilder.Entity("TaskProject.Models.Task", b =>
                {
                    b.HasOne("TaskProject.Models.TaskType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}