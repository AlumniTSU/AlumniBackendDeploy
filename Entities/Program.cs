using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

[Keyless]
public partial class Program
{
    [Column("ProgramID")]
    public int ProgramId { get; set; }

    [StringLength(200)]
    public string ProgramName { get; set; } = null!;
}
