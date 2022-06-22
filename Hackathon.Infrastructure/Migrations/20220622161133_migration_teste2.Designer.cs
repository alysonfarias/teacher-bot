﻿// <auto-generated />
using System;
using Hackathon.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hackathon.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220622161133_migration_teste2")]
    partial class migration_teste2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hackathon.Domain.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@api.com",
                            Name = "Admin Root Application",
                            Password = "AQAAAAEAAAPoAAAAEDElrsvZVsnVF/Ukt48iZ4UlWtJ0S0NcimQOKwsZMQeSbOK5WPGGgzIVXRC8e8QI5g==",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserRoleId = 1,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassRoomId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("DueDate")
                        .HasMaxLength(500)
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.HasKey("Id");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("ClassRoomId1");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Arquive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int?>("ActivityId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("DataBase64")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("ActivityId1");

                    b.HasIndex("FileTypeId");

                    b.ToTable("Arquives");
                });

            modelBuilder.Entity("Hackathon.Domain.Models.ClassRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int?>("InstructorId1")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.HasIndex("InstructorId1");

                    b.ToTable("ClassRooms");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "sale de teste",
                            InstructorId = 1,
                            Name = "sala teste",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Enumerations.FileType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("tb_File_Types", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "PDF"
                        },
                        new
                        {
                            Id = 2,
                            Name = "PNG"
                        },
                        new
                        {
                            Id = 3,
                            Name = "JPEG"
                        },
                        new
                        {
                            Id = 4,
                            Name = "JPG"
                        },
                        new
                        {
                            Id = 5,
                            Name = "MP3"
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Enumerations.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("tb_Subjects", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Portuguese"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mathematics"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Programming"
                        },
                        new
                        {
                            Id = 4,
                            Name = "English"
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Enumerations.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("tb_User_Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Instructor"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Student"
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Instructors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2001, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "instru@api.com",
                            Name = "kleber",
                            Password = "AQAAAAEAAAPoAAAAEJlF28Xl49ikFfTUt5ht85nz5cCNGZzhFzHPglz4Q1qRUXF7hVkhNOK/yWR0+fmKQg==",
                            SubjectId = 1,
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserRoleId = 2,
                            Username = "instru"
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ResponsiblePhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2001, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "instru@api.com",
                            Name = "kleber",
                            Password = "AQAAAAEAAAPoAAAAECoU1zgDdLo+739X+uzTV8noB59CwMsj5W4EmKxqIN5FPA755QIw0fNuczyC3QINpA==",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserRoleId = 3,
                            Username = "instru"
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Models.StudentClassRoom", b =>
                {
                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("ClassRoomId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("tb_student_classroom", (string)null);
                });

            modelBuilder.Entity("Hackathon.Domain.Admin", b =>
                {
                    b.HasOne("Hackathon.Domain.Models.Enumerations.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Activity", b =>
                {
                    b.HasOne("Hackathon.Domain.Models.ClassRoom", null)
                        .WithMany("Activities")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.Domain.Models.ClassRoom", "ClassRoom")
                        .WithMany()
                        .HasForeignKey("ClassRoomId1");

                    b.Navigation("ClassRoom");
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Arquive", b =>
                {
                    b.HasOne("Hackathon.Domain.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.Domain.Models.Activity", null)
                        .WithMany("Arquives")
                        .HasForeignKey("ActivityId1");

                    b.HasOne("Hackathon.Domain.Models.Enumerations.FileType", "FileType")
                        .WithMany()
                        .HasForeignKey("FileTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("FileType");
                });

            modelBuilder.Entity("Hackathon.Domain.Models.ClassRoom", b =>
                {
                    b.HasOne("Hackathon.Domain.Models.Instructor", null)
                        .WithMany("Classrooms")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Hackathon.Domain.Models.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId1");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Instructor", b =>
                {
                    b.HasOne("Hackathon.Domain.Models.Enumerations.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.Domain.Models.Enumerations.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Student", b =>
                {
                    b.HasOne("Hackathon.Domain.Models.Enumerations.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Hackathon.Domain.Models.StudentClassRoom", b =>
                {
                    b.HasOne("Hackathon.Domain.Models.ClassRoom", "ClassRoom")
                        .WithMany()
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.Domain.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassRoom");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Activity", b =>
                {
                    b.Navigation("Arquives");
                });

            modelBuilder.Entity("Hackathon.Domain.Models.ClassRoom", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Instructor", b =>
                {
                    b.Navigation("Classrooms");
                });
#pragma warning restore 612, 618
        }
    }
}
