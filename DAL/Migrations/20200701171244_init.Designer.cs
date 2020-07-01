﻿// <auto-generated />
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(TaskManagerContext))]
    [Migration("20200701171244_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("DAL.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rols")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Rols = "Manager",
                            UserName = "Manager"
                        },
                        new
                        {
                            Id = 2,
                            Rols = "Employee",
                            UserName = "Employee"
                        });
                });

            modelBuilder.Entity("DAL.Models.SubTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Statuse")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TaskItemId");

                    b.ToTable("SubTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "subtask1",
                            Statuse = 0,
                            TaskItemId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "subtask2",
                            Statuse = 0,
                            TaskItemId = 2
                        });
                });

            modelBuilder.Entity("DAL.Models.TaskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Statuse")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TaskItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "task1",
                            Statuse = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "task2",
                            Statuse = 0
                        });
                });

            modelBuilder.Entity("DAL.Models.SubTask", b =>
                {
                    b.HasOne("DAL.Models.TaskItem", "TaskItem")
                        .WithMany("SubTasks")
                        .HasForeignKey("TaskItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
