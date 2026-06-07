using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

[Table("WorkForm")]
public partial class WorkForm
{
    [Key]
    [Column("FormID")]
    public int FormId { get; set; }

    [Column("FormNameGEO")]
    [StringLength(100)]
    public string FormNameGeo { get; set; } = null!;

    [Column("FormNameENG")]
    [StringLength(100)]
    public string FormNameEng { get; set; } = null!;
}
