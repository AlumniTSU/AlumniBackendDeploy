using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class Application
{
    [Key]
    [Column("ApplicationID")]
    public int ApplicationId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(50)]
    public string ApplicationType { get; set; } = null!;

    public int TargetId { get; set; }

    public int StatusId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime AppliedAt { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("Applications")]
    public virtual TimelineStatus Status { get; set; } = null!;
}
