using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

[Table("UserEducation")]
public partial class UserEducation
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ProfileID")]
    public int ProfileId { get; set; }

    [Column("EducationCountryID")]
    public int EducationCountryId { get; set; }

    [Column("EstablishmentTypeID")]
    public int EstablishmentTypeId { get; set; }

    [StringLength(300)]
    public string EstablishmentName { get; set; } = null!;

    public int EducationLevel { get; set; }

    [StringLength(100)]
    public string? StudyField { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    public bool IsStillStudent { get; set; }

    public int? StudyYear { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecordDate { get; set; }
}
