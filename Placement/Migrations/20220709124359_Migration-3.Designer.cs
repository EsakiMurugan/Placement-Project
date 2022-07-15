﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Placement.Models;

namespace Placement.Migrations
{
    [DbContext(typeof(MSContext))]
    [Migration("20220709124359_Migration-3")]
    partial class Migration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Placement.Models.Admin", b =>
                {
                    b.Property<int>("FacultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacultyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacultyId");

                    b.ToTable("admin");
                });

            modelBuilder.Entity("Placement.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AOI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("CGPA")
                        .HasColumnType("real");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Diploma")
                        .HasColumnType("real");

                    b.Property<int>("HOA")
                        .HasColumnType("int");

                    b.Property<int>("Mobile_No")
                        .HasColumnType("int");

                    b.Property<string>("Native_place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reg_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SA")
                        .HasColumnType("int");

                    b.Property<float>("SSLC")
                        .HasColumnType("real");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("XII")
                        .HasColumnType("real");

                    b.HasKey("StudentId");

                    b.ToTable("student");
                });
#pragma warning restore 612, 618
        }
    }
}
