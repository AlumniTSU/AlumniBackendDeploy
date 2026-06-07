using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class News
{
    [Key]
    [Column("NewsID")]
    public int NewsId { get; set; }

    [Column("NewsGUID")]
    public Guid NewsGuid { get; set; }

    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [StringLength(200)]
    public string TitleGeo { get; set; } = null!;

    [StringLength(200)]
    public string? TitleEng { get; set; }

    public string BodyGeo { get; set; } = null!;

    public string? BodyEng { get; set; }

    [StringLength(250)]
    public string SlugGeo { get; set; } = null!;

    [StringLength(250)]
    public string? SlugEng { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime NewsDate { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecordDate { get; set; }

    public bool IsDeleted { get; set; }
}
