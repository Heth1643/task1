using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model;

public partial class Traineedb17Context : DbContext
{
    public Traineedb17Context()
    {
    }

    public Traineedb17Context(DbContextOptions<Traineedb17Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Empdetail> Empdetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WIN-390Q81UT43Q\\SQLEXPRESS2017;Database=traineedb17;User Id=traineedb17;Password=hlmjXcsdRG7aPW63;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompId).HasName("PK__Company__DC0BCC205EB1E971");

            entity.ToTable("Company");

            entity.HasIndex(e => e.ComRef, "UQ__Company__21B46A97C2EDFCC1").IsUnique();

            entity.Property(e => e.CompId).HasColumnName("Comp_Id");
            entity.Property(e => e.ComRef)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Com_ref");
            entity.Property(e => e.CompName)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Comp_name");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Empdetail>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PK__Empdetai__C1971B53494F537A");

            entity.Property(e => e.Dob).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Ename)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PriEmp).HasColumnName("pri_emp");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.Empdetails)
                .HasForeignKey(d => d.Cid)
                .HasConstraintName("FK__Empdetails__Cid__4959E263");
        });
        modelBuilder.HasSequence<int>("s1")
            .StartsAt(10L)
            .HasMin(1L)
            .HasMax(20L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
