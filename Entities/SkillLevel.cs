using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

[Table("SkillLevel")]
public partial class SkillLevel
{
    [Key]
    [Column("LevelID")]
    public int LevelId { get; set; }

    [Column("LevelNameGEO")]
    [StringLength(200)]
    public string LevelNameGeo { get; set; } = null!;

    [Column("LevelNameENG")]
    [StringLength(200)]
    public string LevelNameEng { get; set; } = null!;
}
