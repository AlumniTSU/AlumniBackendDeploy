using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class EstablishmentType
{
    [Key]
    [Column("TypeID")]
    public int TypeId { get; set; }

    [StringLength(100)]
    public string TypeNameGeo { get; set; } = null!;

    [StringLength(100)]
    public string TypeNameEng { get; set; } = null!;
}
