using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class Partner
{
    [Key]
    [Column("PartnerID")]
    public int PartnerId { get; set; }

    [Column("PartnerGUID")]
    public Guid PartnerGuid { get; set; }

    [StringLength(500)]
    public string NameGeo { get; set; } = null!;

    [StringLength(500)]
    public string? NameEng { get; set; }

    [StringLength(50)]
    public string? IdentificationCode { get; set; }

    public string? DescriptionGeo { get; set; }

    public string? DescriptionEng { get; set; }

    public string? Website { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecordDate { get; set; }

    public bool IsDeleted { get; set; }
}
