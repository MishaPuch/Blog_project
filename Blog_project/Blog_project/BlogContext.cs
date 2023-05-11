using System;
using System.Collections.Generic;
using Blog_project.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_project;

public partial class BlogContext : DbContext
{
    public BlogContext()
    {
    }

    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coment> Coments { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<User>? Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=MIHSA;Database=Blog;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coments__3213E83F68E19F79");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.comentBody)
                .HasMaxLength(3000)
                .HasColumnName("coment");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");


        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3213E83F3D5DDCB9");

            entity.ToTable("Post");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.PostBody)
                .HasMaxLength(3000)
                .HasColumnName("post_body");
            entity.Property(e => e.PostTitle)
                .HasMaxLength(200)
                .HasColumnName("post_title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F3AB8697E");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
