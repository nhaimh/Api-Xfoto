﻿// <auto-generated />
using System;
using System.Collections.Generic;
using BnDapi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BnDapi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230407083713_initUser")]
    partial class initUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BnDapi.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BnDapi.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AtuthorId")
                        .HasColumnType("integer");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("AuthorName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DemoDescription")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("BnDapi.Models.DuAnImgae", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DuanId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageA")
                        .HasColumnType("text");

                    b.Property<string>("ImageB")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DuanId");

                    b.ToTable("DuAnImgae");
                });

            modelBuilder.Entity("BnDapi.Models.Duan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("ImageB")
                        .HasColumnType("text");

                    b.Property<List<string>>("ListImg")
                        .HasColumnType("jsonb");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Duans");
                });

            modelBuilder.Entity("BnDapi.Models.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("BnDapi.Models.SanPhamImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageA")
                        .HasColumnType("text");

                    b.Property<string>("ImageB")
                        .HasColumnType("text");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SanPhamId");

                    b.ToTable("SanPhamImage");
                });

            modelBuilder.Entity("BnDapi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BnDapi.Models.Blog", b =>
                {
                    b.HasOne("BnDapi.Models.Author", "Author")
                        .WithMany("Blog")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BnDapi.Models.DuAnImgae", b =>
                {
                    b.HasOne("BnDapi.Models.Duan", "Duan")
                        .WithMany("DuAnImgae")
                        .HasForeignKey("DuanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Duan");
                });

            modelBuilder.Entity("BnDapi.Models.SanPhamImage", b =>
                {
                    b.HasOne("BnDapi.Models.SanPham", "SanPham")
                        .WithMany("SanPhamImages")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("BnDapi.Models.Author", b =>
                {
                    b.Navigation("Blog");
                });

            modelBuilder.Entity("BnDapi.Models.Duan", b =>
                {
                    b.Navigation("DuAnImgae");
                });

            modelBuilder.Entity("BnDapi.Models.SanPham", b =>
                {
                    b.Navigation("SanPhamImages");
                });
#pragma warning restore 612, 618
        }
    }
}
