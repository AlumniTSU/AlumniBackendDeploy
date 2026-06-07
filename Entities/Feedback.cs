using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

[Table("Feedback")]
public partial class Feedback
{
    [Key]
    [Column("FeedbackID")]
    public int FeedbackId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    public string Content { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Rating { get; set; }

    [Column("Added_at", TypeName = "datetime")]
    public DateTime? AddedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecordDate { get; set; }

    public bool IsDeleted { get; set; }

    [Column("DeletedByUserID")]
    public int? DeletedByUserId { get; set; }
}
