using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

[Table("LanguageLevel")]
public partial class LanguageLevel
{
    [Key]
    [Column("LevelID")]
    public int LevelId { get; set; }

    [StringLength(50)]
    public string LevelNameGeo { get; set; } = null!;

    [StringLength(50)]
    public string LevelNameEng { get; set; } = null!;
}
