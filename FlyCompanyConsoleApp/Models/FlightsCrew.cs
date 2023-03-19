using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FlyCompanyConsoleApp.Models;

[Table("flights_crew")]
public partial class FlightsCrew
{
    [Column("flight_id")]
    public int FlightId { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("FlightsCrews")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("FlightId")]
    [InverseProperty("FlightsCrews")]
    public virtual Flight Flight { get; set; } = null!;
}
