﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rest_husky.Data;

#nullable disable

namespace rest_husky.Migrations
{
    [DbContext(typeof(ProfileContext))]
    [Migration("20230926040913_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("rest_husky.Models.Buzz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BuzzEmbed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Buzzes");
                });

            modelBuilder.Entity("rest_husky.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("rest_husky.Models.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ProfileId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("rest_husky.Models.Buzz", b =>
                {
                    b.HasOne("rest_husky.Models.Profile", null)
                        .WithMany("Buzzes")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("rest_husky.Models.Comment", b =>
                {
                    b.HasOne("rest_husky.Models.Profile", null)
                        .WithMany("Comments")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("rest_husky.Models.Profile", b =>
                {
                    b.Navigation("Buzzes");

                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
