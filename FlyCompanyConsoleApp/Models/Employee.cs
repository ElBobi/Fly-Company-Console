using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FlyCompanyConsoleApp.Models;

[Table("employees")]
public partial class Employee
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    [StringLength(30)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(30)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("type")]
    [StringLength(30)]
    [Unicode(false)]
    public string Type { get; set; } = null!;

    [Column("gender")]
    [StringLength(9)]
    [Unicode(false)]
    public string Gender { get; set; } = null!;

    [InverseProperty("Employee")]
    public virtual ICollection<FlightsCrew> FlightsCrews { get; } = new List<FlightsCrew>();
}
