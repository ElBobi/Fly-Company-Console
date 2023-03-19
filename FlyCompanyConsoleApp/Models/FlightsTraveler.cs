using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FlyCompanyConsoleApp.Models;

[Table("flights_travelers")]
public partial class FlightsTraveler
{
    [Column("flight_id")]
    public int FlightId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [ForeignKey("FlightId")]
    [InverseProperty("FlightsTravelers")]
    public virtual Flight Flight { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("FlightsTravelers")]
    public virtual User User { get; set; } = null!;
}
