using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

[Table("NewsCategory")]
public partial class NewsCategory
{
    [Key]
    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [Column("CategoryNameGEO")]
    [StringLength(100)]
    public string CategoryNameGeo { get; set; } = null!;

    [Column("CategoryNameENG")]
    [StringLength(100)]
    public string CategoryNameEng { get; set; } = null!;
}
