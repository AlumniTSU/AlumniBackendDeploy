using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

[Table("EducationLevel")]
public partial class EducationLevel
{
    [Key]
    [Column("levelID")]
    public int LevelId { get; set; }

    [StringLength(100)]
    public string LevelNameGeo { get; set; } = null!;

    [StringLength(100)]
    public string LevelNameEng { get; set; } = null!;
}
