using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FlyCompanyConsoleApp.Models;

[Table("flights")]
public partial class Flight
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("from_destination")]
    [StringLength(100)]
    [Unicode(false)]
    public string FromDestination { get; set; } = null!;

    [Column("to_destination")]
    [StringLength(100)]
    [Unicode(false)]
    public string ToDestination { get; set; } = null!;

    [Column("take_off_time", TypeName = "date")]
    public DateTime TakeOffTime { get; set; }

    [Column("land_time", TypeName = "date")]
    public DateTime LandTime { get; set; }

    [Column("plane_id")]
    public int PlaneId { get; set; }

    [InverseProperty("Flight")]
    public virtual ICollection<CanceledFlight> CanceledFlights { get; } = new List<CanceledFlight>();

    [InverseProperty("Flight")]
    public virtual ICollection<FlightsCrew> FlightsCrews { get; } = new List<FlightsCrew>();

    [InverseProperty("Flight")]
    public virtual ICollection<FlightsTraveler> FlightsTravelers { get; } = new List<FlightsTraveler>();

    [ForeignKey("PlaneId")]
    [InverseProperty("Flights")]
    public virtual Plane Plane { get; set; } = null!;

    public override string ToString()
    {
        return $"Id: {Id}\nTaking off: {TakeOffTime}\nFrom: {FromDestination}\nTo: {ToDestination}";
    }
}
