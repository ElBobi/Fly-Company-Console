using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FlyCompanyConsoleApp.Models;

[Table("planes")]
public partial class Plane
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("capacity")]
    public int Capacity { get; set; }

    [InverseProperty("Plane")]
    public virtual ICollection<Flight> Flights { get; } = new List<Flight>();
}
