using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FlyCompanyConsoleApp.Models;

public partial class FlyContext : DbContext
{
    public FlyContext()
    {
    }

    public FlyContext(DbContextOptions<FlyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CanceledFlight> CanceledFlights { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<FlightsCrew> FlightsCrews { get; set; }

    public virtual DbSet<FlightsTraveler> FlightsTravelers { get; set; }

    public virtual DbSet<Plane> Planes { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Fly;Integrated Security = True;;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CanceledFlight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__canceled__3213E83F9434E783");

            entity.HasOne(d => d.Flight).WithMany(p => p.CanceledFlights)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__canceled___fligh__4F7CD00D");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F7FC4A9EC");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__flights__3213E83F455E39EF");

            entity.HasOne(d => d.Plane).WithMany(p => p.Flights)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__flights__plane_i__412EB0B6");
        });

        modelBuilder.Entity<FlightsCrew>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__flights___3213E83FF9F04661");

            entity.HasOne(d => d.Employee).WithMany(p => p.FlightsCrews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__flights_c__emplo__4D94879B");

            entity.HasOne(d => d.Flight).WithMany(p => p.FlightsCrews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__flights_c__fligh__4CA06362");
        });

        modelBuilder.Entity<FlightsTraveler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__flights___3213E83F2A10C4EA");

            entity.HasOne(d => d.Flight).WithMany(p => p.FlightsTravelers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__flights_t__fligh__49C3F6B7");

            entity.HasOne(d => d.User).WithMany(p => p.FlightsTravelers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__flights_t__user___4AB81AF0");
        });

        modelBuilder.Entity<Plane>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__planes__3213E83F6B6BAC36");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__seats__3213E83F4B8C7C8E");

            entity.HasOne(d => d.Plane).WithMany(p => p.Seats)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__seats__plane_id__440B1D61");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F6B02A6CB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
