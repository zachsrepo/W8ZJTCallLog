using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CallLogTesting.Models;

public partial class FccAmateurContext : DbContext
{
    public FccAmateurContext()
    {
    }

    public FccAmateurContext(DbContextOptions<FccAmateurContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Am> Ams { get; set; }

    public virtual DbSet<En> Ens { get; set; }

    public virtual DbSet<Hd> Hds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=(localDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\DBs\\fcc_amateur.mdf;Integrated Security = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Am>(entity =>
        {
            entity.HasKey(e => e.Fccid).HasName("PK_am_fccid");

            entity.ToTable("am", "fcc_amateur");

            entity.HasIndex(e => e.Callsign, "idx_callsign");

            entity.HasIndex(e => e.Class, "idx_class");

            entity.Property(e => e.Fccid)
                .ValueGeneratedNever()
                .HasColumnName("fccid");
            entity.Property(e => e.Callsign)
                .HasMaxLength(8)
                .HasColumnName("callsign");
            entity.Property(e => e.Class)
                .HasMaxLength(1)
                .HasColumnName("class");
            entity.Property(e => e.Col4)
                .HasMaxLength(1)
                .HasColumnName("col4");
            entity.Property(e => e.Col5)
                .HasMaxLength(2)
                .HasColumnName("col5");
            entity.Property(e => e.Col6)
                .HasMaxLength(3)
                .HasColumnName("col6");
            entity.Property(e => e.FormerCall)
                .HasMaxLength(8)
                .HasColumnName("former_call");
            entity.Property(e => e.FormerClass)
                .HasMaxLength(1)
                .HasColumnName("former_class");
        });

        modelBuilder.Entity<En>(entity =>
        {
            entity.HasKey(e => e.Fccid).HasName("PK_en_fccid");

            entity.ToTable("en", "fcc_amateur");

            entity.HasIndex(e => e.Callsign, "idx_callsign");

            entity.HasIndex(e => e.Zip, "idx_zip");

            entity.Property(e => e.Fccid)
                .ValueGeneratedNever()
                .HasColumnName("fccid");
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .HasColumnName("address1");
            entity.Property(e => e.Callsign)
                .HasMaxLength(8)
                .HasColumnName("callsign");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.First)
                .HasMaxLength(50)
                .HasColumnName("first");
            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .HasColumnName("full_name");
            entity.Property(e => e.Last)
                .HasMaxLength(50)
                .HasColumnName("last");
            entity.Property(e => e.Middle)
                .HasMaxLength(1)
                .HasColumnName("middle");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .HasColumnName("state");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .HasColumnName("zip");
        });

        modelBuilder.Entity<Hd>(entity =>
        {
            entity.HasKey(e => e.Fccid).HasName("PK_hd_fccid");

            entity.ToTable("hd", "fcc_amateur");

            entity.HasIndex(e => e.Callsign, "idx_callsign");

            entity.HasIndex(e => e.Status, "idx_status");

            entity.Property(e => e.Fccid)
                .ValueGeneratedNever()
                .HasColumnName("fccid");
            entity.Property(e => e.Callsign)
                .HasMaxLength(8)
                .HasColumnName("callsign");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
