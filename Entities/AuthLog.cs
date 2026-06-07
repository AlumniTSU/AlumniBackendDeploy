using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class AuthLog
{
    [Key]
    [Column("LogID")]
    public int LogId { get; set; }

    public int UserId { get; set; }

    [StringLength(100)]
    public string Action { get; set; } = null!;

    [StringLength(100)]
    public string? IpAddress { get; set; }

    [Column("UpdatedByUserID")]
    public int? UpdatedByUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecordDate { get; set; }
}
