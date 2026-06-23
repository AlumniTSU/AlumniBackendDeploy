using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

[Keyless]
[Table("Excel_CS_students")]
public partial class ExcelCsStudent
{
    [Column("studId")]
    public int StudId { get; set; }

    [Column("fName")]
    [StringLength(50)]
    public string FName { get; set; } = null!;

    [Column("sName")]
    [StringLength(50)]
    public string? SName { get; set; }

    [Column("fNameEn")]
    [StringLength(50)]
    public string? FNameEn { get; set; }

    [Column("sNameEn")]
    [StringLength(50)]
    public string? SNameEn { get; set; }

    [Column("persNumber")]
    [StringLength(50)]
    public string? PersNumber { get; set; }

    [Column("passportNumber")]
    [StringLength(50)]
    public string? PassportNumber { get; set; }

    [Column("sex")]
    [StringLength(50)]
    public string? Sex { get; set; }

    [Column("sexId")]
    public bool? SexId { get; set; }

    [Column("fakulty")]
    [StringLength(50)]
    public string? Fakulty { get; set; }

    [Column("studyLevel")]
    [StringLength(50)]
    public string? StudyLevel { get; set; }

    [Column("studyLevelId")]
    public byte? StudyLevelId { get; set; }

    [Column("studyProgram")]
    [StringLength(50)]
    public string? StudyProgram { get; set; }

    [Column("programId")]
    public short? ProgramId { get; set; }

    [Column("programGroupId")]
    public short? ProgramGroupId { get; set; }

    [Column("specialization")]
    [StringLength(50)]
    public string? Specialization { get; set; }

    [Column("specializationId")]
    [StringLength(50)]
    public string? SpecializationId { get; set; }

    [Column("facultyId")]
    public byte? FacultyId { get; set; }

    [Column("studyYear")]
    [StringLength(50)]
    public string? StudyYear { get; set; }

    [Column("studyYearId")]
    public byte? StudyYearId { get; set; }

    [Column("studySemester")]
    [StringLength(50)]
    public string? StudySemester { get; set; }

    [Column("studySemesterId")]
    public byte? StudySemesterId { get; set; }

    [Column("semesterPayment")]
    [StringLength(50)]
    public string? SemesterPayment { get; set; }

    [Column("creditPayment")]
    [StringLength(50)]
    public string? CreditPayment { get; set; }

    [Column("complateYear")]
    [StringLength(50)]
    public string? ComplateYear { get; set; }

    [Column("naecReiting")]
    public double? NaecReiting { get; set; }

    [Column("studentCode")]
    [StringLength(20)]
    public string? StudentCode { get; set; }

    [Column("birthDay")]
    [StringLength(20)]
    public string? BirthDay { get; set; }

    [Column("mobile")]
    [StringLength(50)]
    public string? Mobile { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("semester")]
    public byte? Semester { get; set; }

    [Column("programCoreSemester")]
    public byte? ProgramCoreSemester { get; set; }

    [Column("studyStatus")]
    [StringLength(50)]
    public string? StudyStatus { get; set; }

    [Column("avgMark")]
    [StringLength(50)]
    public string? AvgMark { get; set; }

    [Column("gpa")]
    [StringLength(50)]
    public string? Gpa { get; set; }

    [Column("gpaDanarti")]
    [StringLength(50)]
    public string? GpaDanarti { get; set; }

    [Column("sumCredits")]
    [StringLength(50)]
    public string? SumCredits { get; set; }

    [Column("personId")]
    public int? PersonId { get; set; }

    [Column("fileId")]
    [StringLength(50)]
    public string? FileId { get; set; }

    [Column("debt")]
    public double? Debt { get; set; }

    [Column("grant")]
    [StringLength(50)]
    public string? Grant { get; set; }

    [Column("socialGrant")]
    [StringLength(50)]
    public string? SocialGrant { get; set; }

    [Column("ufasoGrant")]
    [StringLength(50)]
    public string? UfasoGrant { get; set; }

    [Column("otherGrant")]
    [StringLength(50)]
    public string? OtherGrant { get; set; }

    [Column("adminRegPrecondition")]
    public bool? AdminRegPrecondition { get; set; }

    [Column("adminRegManualAllowed")]
    [StringLength(50)]
    public string? AdminRegManualAllowed { get; set; }

    [Column("akadRegistrationPassed")]
    public bool? AkadRegistrationPassed { get; set; }

    [Column("enterYear")]
    public short? EnterYear { get; set; }

    [Column("column49")]
    [StringLength(1)]
    public string? Column49 { get; set; }
}
