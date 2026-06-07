using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities;

public partial class AlumniDBContext : DbContext
{
    public AlumniDBContext(DbContextOptions<AlumniDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdvertisementType> AdvertisementTypes { get; set; } = null!;

    public virtual DbSet<AlumniProfile> AlumniProfiles { get; set; } = null!;

    public virtual DbSet<Application> Applications { get; set; } = null!;

    public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; } = null!;

    public virtual DbSet<AuthLog> AuthLogs { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<EducationLevel> EducationLevels { get; set; }

    public virtual DbSet<EstablishmentType> EstablishmentTypes { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<FileType> FileTypes { get; set; }

    public virtual DbSet<Interest> Interests { get; set; }

    public virtual DbSet<JobAdvertisement> JobAdvertisements { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LanguageLevel> LanguageLevels { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsCategory> NewsCategories { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillLevel> SkillLevels { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<TimelineStatus> TimelineStatuses { get; set; }

    public virtual DbSet<UniversityAccount> UniversityAccounts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserEducation> UserEducations { get; set; }

    public virtual DbSet<UserInterest> UserInterests { get; set; }

    public virtual DbSet<UserLanguage> UserLanguages { get; set; }

    public virtual DbSet<UserSkill> UserSkills { get; set; }

    public virtual DbSet<UserWorkExperience> UserWorkExperiences { get; set; }

    public virtual DbSet<WorkForm> WorkForms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdvertisementType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Advertis__516F03952272A539");

            entity.Property(e => e.TypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AlumniProfile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__UserProf__290C8884D64D5A9C");

            entity.Property(e => e.RecordDate).HasDefaultValueSql("(getdate())", "DF__UserProfi__Recor__0662F0A3");

            entity.HasOne(d => d.User).WithMany(p => p.AlumniProfiles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserProfi__UserI__056ECC6A");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__Applicat__3213E83F025DC0FC");

            entity.Property(e => e.ApplicationId).ValueGeneratedNever();

            entity.HasOne(d => d.Status).WithMany(p => p.Applications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Applicati__Statu__02FC7413");
        });

        modelBuilder.Entity<ApplicationStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Applicat__C8EE20432C3E553E");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AuthLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__AuthLogs__5E5499A83E558FA8");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Countrie__10D160BF50637497");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.DocumentTypeId).HasName("PK__Document__DBA390E19B3A086F");
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.DonationId).HasName("PK__Donation__C5082EDB44911E0C");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())", "DF__Donations__Creat__3E723F9C");
        });

        modelBuilder.Entity<EducationLevel>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PK__Educatio__FB05B7BD39020474");
        });

        modelBuilder.Entity<EstablishmentType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Establis__516F0395CA85766B");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__7944C870A8523219");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF62ABF8D15");
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("PK__Files__6F0F989F0A9F0C60");
        });

        modelBuilder.Entity<FileType>(entity =>
        {
            entity.Property(e => e.FileTypeId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Interest>(entity =>
        {
            entity.HasKey(e => e.InterestId).HasName("PK__Interest__3213E83F2143034B");

            entity.Property(e => e.InterestId).ValueGeneratedNever();
        });

        modelBuilder.Entity<JobAdvertisement>(entity =>
        {
            entity.HasKey(e => e.AdvertisementId).HasName("PK__JobAdver__C4C7F42D70C62E81");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK__Language__B938558BEEC9957F");
        });

        modelBuilder.Entity<LanguageLevel>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PK__Language__09F03C069A854586");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PK__News__954EBDD3FCBA1692");

            entity.Property(e => e.RecordDate).HasDefaultValueSql("(getdate())", "DF__News__RecordDate__67DE6983");
        });

        modelBuilder.Entity<NewsCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__NewsCate__19093A2BEA800437");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__3213E83F3B11F4ED");

            entity.Property(e => e.NotificationId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.PartnerId).HasName("PK__Partners__39FD63327FEFCC88");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A582D8A0F4C");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__UserID__47FBA9D6");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__3213E83FD2C84CDE");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__Skills__3213E83F9188CC65");

            entity.Property(e => e.SkillId).ValueGeneratedNever();
        });

        modelBuilder.Entity<SkillLevel>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PK__SkillLev__09F03C06D4CEE76A");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52A79E8B99218");
        });

        modelBuilder.Entity<TimelineStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__3213E83F50971B95");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UniversityAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Universi__349DA5868B35C6EF");

            entity.Property(e => e.Balance).HasDefaultValue(0m);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC1F8D1E89");

            entity.Property(e => e.RoleId).HasDefaultValue(2, "DF__Users__RoleID__1C5231C2");
        });

        modelBuilder.Entity<UserEducation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserEduc__3214EC2753C93B91");

            entity.Property(e => e.RecordDate).HasDefaultValueSql("(getdate())", "DF__UserEduca__Recor__093F5D4E");
        });

        modelBuilder.Entity<UserInterest>(entity =>
        {
            entity.HasKey(e => e.UserInterestId).HasName("PK__UserInte__28E6EBDE915CAD19");
        });

        modelBuilder.Entity<UserLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserLang__3214EC27F60F3D1C");

            entity.Property(e => e.RecordDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<UserSkill>(entity =>
        {
            entity.HasKey(e => e.UserSkillId).HasName("PK__UserSkil__2F28BFB679A1A75C");
        });

        modelBuilder.Entity<UserWorkExperience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserWork__3214EC27C9279BEC");
        });

        modelBuilder.Entity<WorkForm>(entity =>
        {
            entity.HasKey(e => e.FormId).HasName("PK__WorkForm__FB05B7BD43B6BFE9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
