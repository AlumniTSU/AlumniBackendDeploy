using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class UserInterest
{
    [Key]
    [Column("UserInterestID")]
    public int UserInterestId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("InterestID")]
    public int InterestId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecordDate { get; set; }
}
