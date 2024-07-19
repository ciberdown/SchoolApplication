﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolApplication.src.Data;

#nullable disable

namespace SchoolApplication.Migrations
{
    [DbContext(typeof(SchoolDb))]
    [Migration("20240719131254_AddStudentCourses")]
    partial class AddStudentCourses
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolApplication.src.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("SchoolId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("SchoolApplication.src.Models.Scholarship", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("AimSchoolId")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("StudentId", "AimSchoolId");

                    b.HasIndex("AimSchoolId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Scholarships");
                });

            modelBuilder.Entity("SchoolApplication.src.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("SchoolApplication.src.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolApplication.src.Models.StudentCourse", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("SchoolApplication.src.Models.Course", b =>
                {
                    b.HasOne("SchoolApplication.src.Models.School", "EventPlaceSchool")
                        .WithMany("Courses")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventPlaceSchool");
                });

            modelBuilder.Entity("SchoolApplication.src.Models.Scholarship", b =>
                {
                    b.HasOne("SchoolApplication.src.Models.School", "School")
                        .WithMany("TakedScholarships")
                        .HasForeignKey("AimSchoolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SchoolApplication.src.Models.Student", "Student")
                        .WithOne("Scholarship")
                        .HasForeignKey("SchoolApplication.src.Models.Scholarship", "StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("School");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolApplication.src.Models.Student", b =>
                {
                    b.HasOne("SchoolApplication.src.Models.School", "School")
                        .WithMany("Students")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("SchoolApplication.src.Models.StudentCourse", b =>
                {
                    b.HasOne("SchoolApplication.src.Models.Course", "Course")
                        .WithMany("EnrolledStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SchoolApplication.src.Models.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolApplication.src.Models.Course", b =>
                {
                    b.Navigation("EnrolledStudents");
                });

            modelBuilder.Entity("SchoolApplication.src.Models.School", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Students");

                    b.Navigation("TakedScholarships");
                });

            modelBuilder.Entity("SchoolApplication.src.Models.Student", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Scholarship");
                });
#pragma warning restore 612, 618
        }
    }
}
