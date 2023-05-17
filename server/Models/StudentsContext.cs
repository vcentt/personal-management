using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models;

public partial class StudentsContext : DbContext
{
    public StudentsContext()
    {
    }

    public StudentsContext(DbContextOptions<StudentsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Infostudent> Infostudents { get; set; }

    public virtual DbSet<Personalstudent> Personalstudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Infostudent>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("infostudent_pkey");

            entity.ToTable("infostudent");

            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Bootcamp)
                .HasMaxLength(100)
                .HasColumnName("bootcamp");
            entity.Property(e => e.English)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("english");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Isgraduated).HasColumnName("isgraduated");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Numgroup).HasColumnName("numgroup");
            entity.Property(e => e.Photo)
                .HasMaxLength(500)
                .HasColumnName("photo");
            entity.Property(e => e.Tps)
                .HasMaxLength(100)
                .HasColumnName("tps");
        });

        modelBuilder.Entity<Personalstudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("personalstudent");

            entity.Property(e => e.Adress)
                .HasMaxLength(200)
                .HasColumnName("adress");
            entity.Property(e => e.Contract).HasColumnName("contract");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(13)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Studentid).HasColumnName("studentid");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.Studentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personalstudent_studentid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
