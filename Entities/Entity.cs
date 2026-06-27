using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class Entity
{
    [Key]
    [Column("EntityID")]
    public int EntityId { get; set; }

    [StringLength(1000)]
    public string EntityNameGeo { get; set; } = null!;

    [StringLength(1000)]
    public string EntityNameEng { get; set; } = null!;
}
