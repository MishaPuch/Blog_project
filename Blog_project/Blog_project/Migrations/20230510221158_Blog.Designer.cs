﻿// <auto-generated />
using System;
using Blog_project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blog_project.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20230510221158_Blog")]
    partial class Blog
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Blog_project.Models.Coment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("post_id");

                    b.Property<string>("comentBody")
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)")
                        .HasColumnName("coment");

                    b.HasKey("Id")
                        .HasName("PK__Coments__3213E83F68E19F79");

                    b.HasIndex("UserId");

                    b.ToTable("Coments");
                });

            modelBuilder.Entity("Blog_project.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("PostBody")
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)")
                        .HasColumnName("post_body");

                    b.Property<string>("PostTitle")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("post_title");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__Post__3213E83F3D5DDCB9");

                    b.HasIndex("UserId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("Blog_project.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("PK__Users__3213E83F3AB8697E");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Blog_project.Models.Coment", b =>
                {
                    b.HasOne("Blog_project.Models.User", null)
                        .WithMany("Coments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Blog_project.Models.Post", b =>
                {
                    b.HasOne("Blog_project.Models.User", null)
                        .WithMany("Posts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Blog_project.Models.User", b =>
                {
                    b.Navigation("Coments");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
