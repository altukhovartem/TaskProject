// <auto-generated />
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
    [Migration("20210719161258_SeedDateAdded")]
    partial class SeedDateAdded
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

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(2021, 7, 19, 19, 12, 57, 810, DateTimeKind.Local).AddTicks(1639),
                            Title = "First Task",
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedTime = new DateTime(2021, 7, 19, 19, 12, 57, 812, DateTimeKind.Local).AddTicks(4437),
                            Title = "Second Task",
                            Type = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedTime = new DateTime(2021, 7, 19, 19, 12, 57, 812, DateTimeKind.Local).AddTicks(4631),
                            Title = "Third Task",
                            Type = 3
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
#pragma warning restore 612, 618
        }
    }
}
