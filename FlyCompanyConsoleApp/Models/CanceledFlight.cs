using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FlyCompanyConsoleApp.Models;

[Table("canceled_flights")]
public partial class CanceledFlight
{
    [Column("flight_id")]
    public int FlightId { get; set; }

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [ForeignKey("FlightId")]
    [InverseProperty("CanceledFlights")]
    public virtual Flight Flight { get; set; } = null!;
}
