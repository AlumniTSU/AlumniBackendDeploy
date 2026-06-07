using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class UserSkill
{
    [Key]
    [Column("UserSkillID")]
    public int UserSkillId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("SkillID")]
    public int SkillId { get; set; }

    [StringLength(100)]
    public string? Level { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecordDate { get; set; }
}
