using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Results.Event
{
    public class GetEventByIdResult
    {
        [Column("EventID")]
        public int EventId {get; set;}
        public Guid EventUid { get; set; }
        public string? Title {get; set;}
        public string? Description {get; set;}
        public DateTime? EventDate {get; set;}
        public int CreatedBy {get; set;}
        public byte[]? File {get; set;}
        public bool? IsMainPic {get; set;}
        [Column("FileTypeID")]
        public int? FileTypeID {get; set;}
        public string? Extension {get; set;}
        public int? PartnerId {get; set;}
        public DateTime CreatedAt {get; set;}
        public int UpdatedBy {get; set;}
    }
}