﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManager.Data;

#nullable disable

namespace TaskManager.Data.Migrations
{
    [DbContext(typeof(TasksContext))]
    [Migration("20241025055330_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManager.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Due")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ToDos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Due = new DateTime(2024, 11, 1, 1, 53, 29, 542, DateTimeKind.Local).AddTicks(8774),
                            State = "Not Started",
                            Title = "Complete Project Proposal"
                        },
                        new
                        {
                            Id = 2,
                            Due = new DateTime(2024, 10, 28, 1, 53, 29, 542, DateTimeKind.Local).AddTicks(8833),
                            State = "In Progress",
                            Title = "Review Code Changes"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}