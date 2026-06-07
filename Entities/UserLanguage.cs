using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class UserLanguage
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("LanguageID")]
    public int LanguageId { get; set; }

    [Column("LevelID")]
    public int LevelId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecordDate { get; set; }

    public bool IsDeleted { get; set; }
}
