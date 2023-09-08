using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LostAndFound.Models;

public partial class LostAndFoundContext : DbContext
{
    public LostAndFoundContext()
    {
    }

    public LostAndFoundContext(DbContextOptions<LostAndFoundContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ItemDetailsBackup> ItemDetailsBackups { get; set; }

    public virtual DbSet<ItemTable> ItemTables { get; set; }

    public virtual DbSet<UserTable> UserTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CVC233;Initial Catalog=LostAndFound;Persist Security Info=True;Encrypt=false; User ID=sa;Password=cybage@123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemDetailsBackup>(entity =>
        {
            entity.HasKey(e => e.BackUpId).HasName("PK__ItemDeta__2E2C87907525EE58");

            entity.ToTable("ItemDetailsBackup");

            entity.Property(e => e.DeleteDate).HasColumnType("datetime");
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TypeOfOperation)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.ItemTable).WithMany(p => p.ItemDetailsBackups)
                .HasForeignKey(d => d.ItemTableId)
                .HasConstraintName("FK__ItemDetai__ItemT__3E52440B");
        });

        modelBuilder.Entity<ItemTable>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__ItemTabl__727E838BA03B2FBF");

            entity.ToTable("ItemTable");

            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FloorNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FoundSeatLocation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsFound).HasDefaultValueSql("((0))");
            entity.Property(e => e.ItemName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.ItemTables)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("foreign_key_constraint");
        });

        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserTabl__1788CC4CC64EAF3B");

            entity.ToTable("UserTable");

            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
