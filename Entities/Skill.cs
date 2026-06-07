using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class Skill
{
    [Key]
    [Column("SkillID")]
    public int SkillId { get; set; }

    [StringLength(200)]
    public string NameGeo { get; set; } = null!;

    [StringLength(200)]
    public string? NameEng { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }
}
