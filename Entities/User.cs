using System;
using System.Collections.Generic;

namespace backend.Entities;

public partial class User
{
    public int UserId { get; set; }

    public int? StudentId { get; set; }

    public int RoleId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string PersonalId { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public int? AddedBy { get; set; }

    public bool IsDeleted { get; set; }

    public int FailedLoginAttempts { get; set; }

    public bool IsLocked { get; set; }

    public DateTime? LockedUntil { get; set; }
}
