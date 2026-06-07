using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class Event
{
    [Key]
    [Column("EventID")]
    public int EventId { get; set; }

    [Column("EventUID")]
    public Guid EventUid { get; set; }

    [StringLength(500)]
    public string TitleGeo { get; set; } = null!;

    [StringLength(500)]
    public string? TitleEng { get; set; }

    public string? DescriptionGeo { get; set; }

    [StringLength(500)]
    public string? DescriptionEng { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EventDate { get; set; }

    public int CreatedBy { get; set; }

    public int? PartnerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    public int UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecordDate { get; set; }

    public bool IsDeleted { get; set; }
}
