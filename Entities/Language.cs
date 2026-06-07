using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class Language
{
    [Key]
    [Column("LanguageID")]
    public int LanguageId { get; set; }

    [StringLength(100)]
    public string LanguageNameGeo { get; set; } = null!;

    [StringLength(100)]
    public string LanguageNameEng { get; set; } = null!;

    [StringLength(100)]
    public string LanguageNameNative { get; set; } = null!;
}
