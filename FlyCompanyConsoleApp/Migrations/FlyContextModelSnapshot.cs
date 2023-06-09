﻿// <auto-generated />
using System;
using FlyCompanyConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlyCompanyConsoleApp.Migrations
{
    [DbContext(typeof(FlyContext))]
    partial class FlyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.CanceledFlight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FlightId")
                        .HasColumnType("int")
                        .HasColumnName("flight_id");

                    b.HasKey("Id")
                        .HasName("PK__canceled__3213E83F9434E783");

                    b.HasIndex("FlightId");

                    b.ToTable("canceled_flights");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("first_name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("last_name");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("PK__employee__3213E83F7FC4A9EC");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FromDestination")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("from_destination");

                    b.Property<DateTime>("LandTime")
                        .HasColumnType("date")
                        .HasColumnName("land_time");

                    b.Property<int>("PlaneId")
                        .HasColumnType("int")
                        .HasColumnName("plane_id");

                    b.Property<DateTime>("TakeOffTime")
                        .HasColumnType("date")
                        .HasColumnName("take_off_time");

                    b.Property<string>("ToDestination")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("to_destination");

                    b.HasKey("Id")
                        .HasName("PK__flights__3213E83F455E39EF");

                    b.HasIndex("PlaneId");

                    b.ToTable("flights");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.FlightsCrew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    b.Property<int>("FlightId")
                        .HasColumnType("int")
                        .HasColumnName("flight_id");

                    b.HasKey("Id")
                        .HasName("PK__flights___3213E83FF9F04661");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FlightId");

                    b.ToTable("flights_crew");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.FlightsTraveler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FlightId")
                        .HasColumnType("int")
                        .HasColumnName("flight_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__flights___3213E83F2A10C4EA");

                    b.HasIndex("FlightId");

                    b.HasIndex("UserId");

                    b.ToTable("flights_travelers");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("capacity");

                    b.Property<int>("CountOfFirstClassSeats")
                        .HasColumnType("int")
                        .HasColumnName("count_of_first_class_seats");

                    b.Property<int>("CountOfSecondClassSeats")
                        .HasColumnType("int")
                        .HasColumnName("count_of_second_class_seats");

                    b.HasKey("Id")
                        .HasName("PK__planes__3213E83F6B6BAC36");

                    b.ToTable("planes");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("Class")
                        .HasColumnType("tinyint")
                        .HasColumnName("class");

                    b.Property<int>("PlaneId")
                        .HasColumnType("int")
                        .HasColumnName("plane_id");

                    b.HasKey("Id")
                        .HasName("PK__seats__3213E83F4B8C7C8E");

                    b.HasIndex("PlaneId");

                    b.ToTable("seats");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("first_name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)")
                        .HasColumnName("gender");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<bool?>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("is_admin");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.Property<DateTime?>("RegisterDate")
                        .HasColumnType("date")
                        .HasColumnName("register_date");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("PK__Users__3213E83F6B02A6CB");

                    b.HasIndex(new[] { "PhoneNumber" }, "UQ__Users__A1936A6B755A72C2")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Users__AB6E61643137215D")
                        .IsUnique();

                    b.HasIndex(new[] { "Username" }, "UQ__Users__F3DBC5728F2F953F")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.CanceledFlight", b =>
                {
                    b.HasOne("FlyCompanyConsoleApp.Models.Flight", "Flight")
                        .WithMany("CanceledFlights")
                        .HasForeignKey("FlightId")
                        .IsRequired()
                        .HasConstraintName("FK__canceled___fligh__4F7CD00D");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.Flight", b =>
                {
                    b.HasOne("FlyCompanyConsoleApp.Models.Plane", "Plane")
                        .WithMany("Flights")
                        .HasForeignKey("PlaneId")
                        .IsRequired()
                        .HasConstraintName("FK__flights__plane_i__412EB0B6");

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.FlightsCrew", b =>
                {
                    b.HasOne("FlyCompanyConsoleApp.Models.Employee", "Employee")
                        .WithMany("FlightsCrews")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__flights_c__emplo__4D94879B");

                    b.HasOne("FlyCompanyConsoleApp.Models.Flight", "Flight")
                        .WithMany("FlightsCrews")
                        .HasForeignKey("FlightId")
                        .IsRequired()
                        .HasConstraintName("FK__flights_c__fligh__4CA06362");

                    b.Navigation("Employee");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.FlightsTraveler", b =>
                {
                    b.HasOne("FlyCompanyConsoleApp.Models.Flight", "Flight")
                        .WithMany("FlightsTravelers")
                        .HasForeignKey("FlightId")
                        .IsRequired()
                        .HasConstraintName("FK__flights_t__fligh__49C3F6B7");

                    b.HasOne("FlyCompanyConsoleApp.Models.User", "User")
                        .WithMany("FlightsTravelers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__flights_t__user___4AB81AF0");

                    b.Navigation("Flight");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.Seat", b =>
                {
                    b.HasOne("FlyCompanyConsoleApp.Models.Plane", "Plane")
                        .WithMany("Seats")
                        .HasForeignKey("PlaneId")
                        .IsRequired()
                        .HasConstraintName("FK__seats__plane_id__440B1D61");

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.Employee", b =>
                {
                    b.Navigation("FlightsCrews");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.Flight", b =>
                {
                    b.Navigation("CanceledFlights");

                    b.Navigation("FlightsCrews");

                    b.Navigation("FlightsTravelers");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.Plane", b =>
                {
                    b.Navigation("Flights");

                    b.Navigation("Seats");
                });

            modelBuilder.Entity("FlyCompanyConsoleApp.Models.User", b =>
                {
                    b.Navigation("FlightsTravelers");
                });
#pragma warning restore 612, 618
        }
    }
}
