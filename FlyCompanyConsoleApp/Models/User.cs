using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FlyCompanyConsoleApp.Models;

[Index("PhoneNumber", Name = "UQ__Users__A1936A6B755A72C2", IsUnique = true)]
[Index("Email", Name = "UQ__Users__AB6E61643137215D", IsUnique = true)]
[Index("Username", Name = "UQ__Users__F3DBC5728F2F953F", IsUnique = true)]
public partial class User
{
    public User(string email, string username, string password, string firstName, string lastName, string gender, string phoneNumber)
    {
        this.Email = email;
        this.Username = username;
        this.Password = password;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Gender = gender;
        this.PhoneNumber = phoneNumber;
        this.RegisterDate= DateTime.Now;
        this.IsActive= true;
        this.IsAdmin = false;
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("email")]
    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Column("username")]
    [StringLength(30)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(30)]
    public string Password { get; set; } = null!;

    [Column("first_name")]
    [StringLength(30)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(30)]
    public string LastName { get; set; } = null!;

    [Column("gender")]
    [StringLength(9)]
    [Unicode(false)]
    public string Gender { get; set; } = null!;

    [Column("phone_number")]
    [StringLength(20)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Column("register_date", TypeName = "date")]
    public DateTime? RegisterDate { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }
    [Column("is_admin")]
    public bool? IsAdmin { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<FlightsTraveler> FlightsTravelers { get; } = new List<FlightsTraveler>();
}
