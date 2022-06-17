﻿// <auto-generated />
using System;
using Hackathon.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hackathon.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hackathon.Domain.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("description");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("dueDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.HasKey("Id");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("Id");

                    b.ToTable("tb_activity", (string)null);
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Arquive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int?>("ActivityId1")
                        .HasColumnType("int");

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("DataBase64")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("dataBase64");

                    b.Property<int>("FileTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("ActivityId1");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("FileTypeId");

                    b.HasIndex("Id");

                    b.ToTable("tb_arquive", (string)null);
                });

            modelBuilder.Entity("Hackathon.Domain.Models.ClassRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("description");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("tb_classroom", (string)null);
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Core.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthDate");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("password");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("userName");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@api.com",
                            Name = "Admin Root Application",
                            Password = "AQAAAAEAAAPoAAAAEPx+ytbWRKAc+Yjy05HlGh3gHVAl2EN18T99RSjA5WJ2hUDS6mFKq56fSkf+NdP8Og==",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserRoleId = 1,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Enumerations.FileType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("FileTypes");

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
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

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
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");

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

            modelBuilder.Entity("Hackathon.Domain.Models.StudentClassRoom", b =>
                {
                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int")
                        .HasColumnName("id_classroom");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("id_student");

                    b.HasKey("ClassRoomId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("tb_student_classroom", (string)null);
                });

            modelBuilder.Entity("Hackathon.Domain.Core.Common.Student", b =>
                {
                    b.HasBaseType("Hackathon.Domain.Models.Core.User");

                    b.Property<string>("ResponsiblePhones")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("tb_student", (string)null);
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Instructor", b =>
                {
                    b.HasBaseType("Hackathon.Domain.Models.Core.User");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasIndex("SubjectId");

                    b.ToTable("tb_instructor", (string)null);
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Activity", b =>
                {
                    b.HasOne("Hackathon.Domain.Models.ClassRoom", "ClassRoom")
                        .WithMany("Activities")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

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

                    b.HasOne("Hackathon.Domain.Models.ClassRoom", "ClassRoom")
                        .WithMany()
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.Domain.Models.Enumerations.FileType", "FileType")
                        .WithMany()
                        .HasForeignKey("FileTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("ClassRoom");

                    b.Navigation("FileType");
                });

            modelBuilder.Entity("Hackathon.Domain.Models.ClassRoom", b =>
                {
                    b.HasOne("Hackathon.Domain.Models.Instructor", "Instructor")
                        .WithMany("Classrooms")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Core.User", b =>
                {
                    b.HasOne("Hackathon.Domain.Models.Enumerations.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
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

                    b.HasOne("Hackathon.Domain.Core.Common.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassRoom");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Hackathon.Domain.Core.Common.Student", b =>
                {
                    b.HasOne("Hackathon.Domain.Models.Core.User", null)
                        .WithOne()
                        .HasForeignKey("Hackathon.Domain.Core.Common.Student", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hackathon.Domain.Models.Instructor", b =>
                {
                    b.HasOne("Hackathon.Domain.Models.Core.User", null)
                        .WithOne()
                        .HasForeignKey("Hackathon.Domain.Models.Instructor", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Hackathon.Domain.Models.Enumerations.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
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
