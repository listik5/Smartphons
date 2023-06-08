using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Smartphons.Models;

public partial class SmartfonsContext : DbContext
{
    public SmartfonsContext()
    {
    }

    public SmartfonsContext(DbContextOptions<SmartfonsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Smartfon> Smartfons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Smartfons;Username=postgres;Password=0806");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Smartfon>(entity =>
        {
            entity.HasKey(e => e.SName).HasName("smartfons_pkey");

            entity.ToTable("smartfons");

            entity.Property(e => e.SName)
                .HasMaxLength(15)
                .HasColumnName("SName");
            entity.Property(e => e.Brend)
                .HasMaxLength(15)
                .HasColumnName("Brend");
            entity.Property(e => e.Chast).HasColumnName("Chast");
            entity.Property(e => e.Diam).HasColumnName("Diam");
            entity.Property(e => e.Ozy).HasColumnName("Ozy");
            entity.Property(e => e.Price).HasColumnName("Price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
