using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

[Table("AlumniProfile")]
public partial class AlumniProfile
{
    [Key]
    [Column("ProfileID")]
    public int ProfileId { get; set; }

    [Column("ProfileGUID")]
    public Guid ProfileGuid { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(1000)]
    public string? Bio { get; set; }

    [StringLength(100)]
    public string? ContactEmail { get; set; }

    [StringLength(20)]
    public string? ContactPhoneNumber { get; set; }

    public string? AdditionalInformation { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecordDate { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("AlumniProfiles")]
    public virtual User User { get; set; } = null!;
}
