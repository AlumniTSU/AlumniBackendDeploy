using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

[Table("Students", Schema = "University")]
public partial class Student
{
    [Key]
    [Column("StudentID")]
    public long StudentId { get; set; }

    [Column("PersonalID")]
    [StringLength(50)]
    public string PersonalId { get; set; } = null!;

    [StringLength(30)]
    public string StudentFirstName { get; set; } = null!;

    [StringLength(100)]
    public string StudentLastName { get; set; } = null!;

    [StringLength(300)]
    public string Email { get; set; } = null!;

    [StringLength(30)]
    public string? PhoneNumber { get; set; }

    public int Semester { get; set; }

    public int Credits { get; set; }

    public bool HasUniversityFinished { get; set; }
}
