﻿// <auto-generated />
using System;
using GuitarStrategiesApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuitarStrategiesApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250225182920_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("GuitarStrategiesApp.Models.LessonNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AttachmentPath")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("URL")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("LessonNotes");
                });

            modelBuilder.Entity("GuitarStrategiesApp.Models.Recommendation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Recommendations");
                });

            modelBuilder.Entity("GuitarStrategiesApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("GuitarStrategiesApp.Models.Student", b =>
                {
                    b.HasBaseType("GuitarStrategiesApp.Models.User");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("TeacherId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("GuitarStrategiesApp.Models.Teacher", b =>
                {
                    b.HasBaseType("GuitarStrategiesApp.Models.User");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("GuitarStrategiesApp.Models.LessonNote", b =>
                {
                    b.HasOne("GuitarStrategiesApp.Models.Student", "Student")
                        .WithMany("LessonNotes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuitarStrategiesApp.Models.Teacher", "Teacher")
                        .WithMany("LessonNotes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("GuitarStrategiesApp.Models.Recommendation", b =>
                {
                    b.HasOne("GuitarStrategiesApp.Models.Teacher", "Teacher")
                        .WithMany("Recommendations")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("GuitarStrategiesApp.Models.Student", b =>
                {
                    b.HasOne("GuitarStrategiesApp.Models.Teacher", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("GuitarStrategiesApp.Models.Student", b =>
                {
                    b.Navigation("LessonNotes");
                });

            modelBuilder.Entity("GuitarStrategiesApp.Models.Teacher", b =>
                {
                    b.Navigation("LessonNotes");

                    b.Navigation("Recommendations");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
