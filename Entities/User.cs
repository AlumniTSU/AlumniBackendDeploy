using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class User
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [Column("StudentID")]
    public int? StudentId { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(100)]
    public string? LastName { get; set; }

    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("phoneNumber")]
    [StringLength(100)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [Column("PersonalID")]
    [StringLength(20)]
    [Unicode(false)]
    public string PersonalId { get; set; } = null!;

    [Column("hashedPassword")]
    [StringLength(255)]
    public string HashedPassword { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastLoginAt { get; set; }

    public int? AddedBy { get; set; }

    public bool IsDeleted { get; set; }

    public int FailedLoginAttempts { get; set; }

    public bool IsLocked { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LockedUntil { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<AlumniProfile> AlumniProfiles { get; set; } = new List<AlumniProfile>();

    [InverseProperty("User")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
