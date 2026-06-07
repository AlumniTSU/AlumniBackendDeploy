using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class File
{
    [Key]
    [Column("FileID")]
    public int FileId { get; set; }

    [Column("ContentGUID")]
    public Guid ContentGuid { get; set; }

    [StringLength(200)]
    public string FileName { get; set; } = null!;

    [Column("File")]
    public byte[] File1 { get; set; } = null!;

    [Column("FileTypeID")]
    public int FileTypeId { get; set; }

    public int UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UploadDate { get; set; }
}
