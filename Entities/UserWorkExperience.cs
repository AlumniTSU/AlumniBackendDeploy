using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

[Table("UserWorkExperience")]
public partial class UserWorkExperience
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ProfileID")]
    public int ProfileId { get; set; }

    [Column("CompanyCountryID")]
    public int CompanyCountryId { get; set; }

    [StringLength(300)]
    public string CompanyName { get; set; } = null!;

    [Column("WorkingFormID")]
    public int WorkingFormId { get; set; }

    [StringLength(200)]
    public string Position { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    public string? AdditionalInfo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecordDate { get; set; }
}
