using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class DocumentType
{
    [Key]
    public int DocumentTypeId { get; set; }

    [Column("DocumentType")]
    [StringLength(100)]
    public string DocumentType1 { get; set; } = null!;
}
