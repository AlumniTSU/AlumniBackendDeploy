using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class JobAdvertisement
{
    [Key]
    [Column("AdvertisementID")]
    public int AdvertisementId { get; set; }

    [Column("AdvertisementGUID")]
    public Guid AdvertisementGuid { get; set; }

    [Column("AdvertisementTypeID")]
    public int AdvertisementTypeId { get; set; }

    public bool IsAlumniAd { get; set; }

    [Column("PartnerID")]
    public int? PartnerId { get; set; }

    [StringLength(500)]
    public string TitleGeo { get; set; } = null!;

    [StringLength(500)]
    public string? TitleEng { get; set; }

    public string DescriptionGeo { get; set; } = null!;

    public string? DescriptionEng { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [StringLength(50)]
    public string? Salary { get; set; }

    [Column("AddedByUserID")]
    public int AddedByUserId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecordDate { get; set; }

    public bool IsDeleted { get; set; }
}
