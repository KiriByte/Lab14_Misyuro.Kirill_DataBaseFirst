using System;
using System.Collections.Generic;
using Lab14_Misyuro.Kirill_DataBaseFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab14_Misyuro.Kirill_DataBaseFirst.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Journal> Journals { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("Employee_PK");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees).HasConstraintName("FK_Employee_Position");
        });

        modelBuilder.Entity<Journal>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("Journal_PK");

            entity.HasOne(d => d.Employee).WithMany(p => p.Journals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Journal_Employee");

            entity.HasOne(d => d.Room).WithMany(p => p.Journals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Journal_Rooms");

            entity.HasOne(d => d.Visitor).WithMany(p => p.Journals)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Journal_Visitor");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("Position_PK");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("Rooms_PK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
