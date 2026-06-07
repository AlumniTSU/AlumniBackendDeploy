using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class UniversityAccount
{
    [Key]
    [Column("AccountID")]
    public int AccountId { get; set; }

    [StringLength(100)]
    public string? AccountName { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? Balance { get; set; }
}
