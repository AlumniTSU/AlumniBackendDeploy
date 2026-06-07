using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class AdvertisementType
{
    [Key]
    [Column("TypeID")]
    public int TypeId { get; set; }

    [StringLength(200)]
    public string TypeName { get; set; } = null!;

    [StringLength(50)]
    public string? TypeNameEng { get; set; }
}
