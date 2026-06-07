using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

[Keyless]
public partial class FileType
{
    [Column("FileTypeID")]
    public int FileTypeId { get; set; }

    [Column("DocumentTypeID")]
    public int DocumentTypeId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Extension { get; set; } = null!;
}
