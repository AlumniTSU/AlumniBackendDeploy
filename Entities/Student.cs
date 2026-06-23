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

    public bool? Gender { get; set; }

    [StringLength(30)]
    public string StudentFirstName { get; set; } = null!;

    [StringLength(100)]
    public string? StudentLastName { get; set; }

    [Column("ProgramID")]
    public int ProgramId { get; set; }

    [StringLength(300)]
    public string? Email { get; set; }

    [StringLength(30)]
    public string? PhoneNumber { get; set; }

    public int? Semester { get; set; }

    public int? Credits { get; set; }

    [StringLength(20)]
    public string? Gpa { get; set; }

    [StringLength(20)]
    public string? AvgMark { get; set; }

    public bool HasUniversityFinished { get; set; }

    public bool? IsUnderGraduateStudent { get; set; }
}
