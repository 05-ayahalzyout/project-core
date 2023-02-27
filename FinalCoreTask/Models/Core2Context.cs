using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinalCoreTask.Models;

public partial class Core2Context : DbContext
{
    public Core2Context()
    {
    }

    public Core2Context(DbContextOptions<Core2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<Doctors2> Doctors2s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.Property(e => e.ClinicImage).IsUnicode(false);
            entity.Property(e => e.ClinicName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Doctors2>(entity =>
        {
            entity.ToTable("Doctors2");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClinicId).HasColumnName("ClinicID");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Clinic).WithMany(p => p.Doctors2s)
                .HasForeignKey(d => d.ClinicId)
                .HasConstraintName("FK_Doctors2_Clinics");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
