using Microsoft.EntityFrameworkCore;
using backend.Results;
using backend.Dtos.Event;
using System.Data;
using Microsoft.Data.SqlClient;

using backend.Dtos.File;
using backend.Dtos.News;
using backend.Dtos.Job;
using backend.Dtos.Feedback;
using backend.Results.News;
using backend.Results.Jobs;
using backend.Results.Event;
using backend.Results.Feedback;
using backend.Results.Statistics;

namespace backend.Entities;

public partial class AlumniDBContext
{
    #region Admin

    public IQueryable<StatisticsResult> GetStatistics(
    DateTime? fromDate,
    DateTime? toDate)
{
    return Database.SqlQuery<StatisticsResult>(
        $@"EXEC dbo.GetStatistics
            @FromTime={fromDate},
            @ToDate={toDate}");
}
    

    #endregion
    
    
    
    #region File

    public async Task<AddFileResult> AddFileAsync(AddFileDto dto)
    {
        var pFileId = new SqlParameter("@FileID", SqlDbType.Int) {Direction = ParameterDirection.Output};
        var pIsAdded = new SqlParameter("@IsAdded", SqlDbType.Bit) {Direction = ParameterDirection.Output};
        var pError = new SqlParameter("@Error", SqlDbType.NVarChar, -1) {Direction = ParameterDirection.Output};

        await Database.ExecuteSqlRawAsync("EXEC dbo.AddFile @ContentGUID, @EntityTypeID, @FileName, @File, @FileTypeID, @UserID, @IsMainPic, @FileID OUTPUT, @IsAdded OUTPUT, @Error OUTPUT",
        new SqlParameter("@ContentGUID", dto.ContentGuid),
        new SqlParameter("@EntityTypeID", dto.EntityTypeId),
        new SqlParameter("@FileName", dto.FileName),
        new SqlParameter("@File", SqlDbType.VarBinary, -1) {Value = dto.File},
        new SqlParameter("@FileTypeID", dto.FileTypeId),
        new SqlParameter("@UserID", dto.UserId),
        new SqlParameter("@IsMainPic", dto.IsMainPic),
        pFileId, pIsAdded, pError
        );

        var isAdded = pIsAdded.Value as bool? ?? false;

        return new AddFileResult
        {
            FileId = isAdded ? (int?)pFileId.Value : null,
            IsAdded = isAdded,
            Error = pError.Value as string,
        };
    }

    #endregion
    
    
    
    #region Events
    public IQueryable<GetEventsResult> GetEvents(int languageId) => Database.SqlQuery<GetEventsResult>($"EXEC dbo.GetEventsByLanguageID @LanguageID={languageId}");

    public async Task<GetEventByIdResult?> GetEventByLanguageIdAndEventIdAsync(int languageId, int eventId)
    {
        var result = await Database.SqlQuery<GetEventByIdResult>($"EXEC GetEventsByLanguageIDAndEVentID @LanguageID={languageId}, @EventID={eventId}").ToListAsync();

        return result.SingleOrDefault();
    }
    
    
    public async Task<AddEventResult> AddEventAsync(CreateEventDto dto, int createdBy)
    {
        var pEventId = new SqlParameter("@EventID", SqlDbType.Int) {Direction = ParameterDirection.Output};
        var pEventUid = new SqlParameter("@EventUID", SqlDbType.UniqueIdentifier) {Direction = ParameterDirection.Output};
        var pIsAdded = new SqlParameter("@IsAdded", SqlDbType.Bit) {Direction = ParameterDirection.Output};
        var pError = new SqlParameter("@Error", SqlDbType.NVarChar, -1) {Direction = ParameterDirection.Output};

        await Database.ExecuteSqlRawAsync(
            "EXEC dbo.AddEvent @TitleGeo, @TitleEng, @DescriptionGeo, @DescriptionEng, @EventDate, @CreatedBy, @PartnerId, @EventID OUTPUT, @EventUID OUTPUT, @IsAdded OUTPUT, @Error OUTPUT",
            new SqlParameter("@TitleGeo", dto.TitleGeo),
            new SqlParameter("@TitleEng", dto.TitleEng),
            new SqlParameter("@DescriptionGeo", dto.DescriptionGeo),
            new SqlParameter("@DescriptionEng", dto.DescriptionEng),
            new SqlParameter("@EventDate", dto.EventDate),
            new SqlParameter("@CreatedBy", createdBy),
            new SqlParameter("@PartnerId", (object?)dto.PartnerId ?? DBNull.Value),
            pEventId, pEventUid, pIsAdded, pError
        );

        var isAdded = pIsAdded.Value as bool? ?? false;

        return new AddEventResult
        {
            EventId = isAdded ? (int?)pEventId.Value : null,
            EventUid = pEventUid.Value as Guid?,
            IsAdded = isAdded,
            Error = pError.Value as string,
        };
    }

    


    public async Task<DeleteEventResult> DeleteEventAsync(int eventId, int updatedBy)
    {
        var pIsDeleted = new SqlParameter("@IsDeleted", SqlDbType.Bit)
        {
            Direction = ParameterDirection.Output
        };

        var pError = new SqlParameter("@Error", SqlDbType.NVarChar, -1)
        {
            Direction = ParameterDirection.Output
        };

        await Database.ExecuteSqlRawAsync(
            "EXEC dbo.DeleteEvent @EventID, @UpdatedBy, @IsDeleted OUTPUT, @Error OUTPUT",
            new SqlParameter("@EventID", eventId),
            new SqlParameter("@UpdatedBy", updatedBy),
            pIsDeleted,
            pError
        );

        return new DeleteEventResult
        {
            IsDeleted = (bool)pIsDeleted.Value,
            Error = pError.Value as string
        };
    }



    public async Task<UpdateEventResult> UpdateEventAsync(int eventId, UpdateEventDto dto, int updatedBy)
    {
        var pIsEdited = new SqlParameter("@IsEdited", SqlDbType.Bit)
        {
            Direction = ParameterDirection.Output
        };

        var pError = new SqlParameter("@Error", SqlDbType.NVarChar, -1)
        {
            Direction = ParameterDirection.Output
        };

        await Database.ExecuteSqlRawAsync(
            @"EXEC dbo.EditEvent
                @EventID,
                @TitleGeo,
                @TitleEng,
                @DescriptionGeo,
                @DescriptionEng,
                @EventDate,
                @PartnerId,
                @UpdatedBy,
                @IsEdited OUTPUT,
                @Error OUTPUT",

            new SqlParameter("@EventID", eventId),
            new SqlParameter("@TitleGeo", (object?)dto.TitleGeo ?? DBNull.Value),
            new SqlParameter("@TitleEng", (object?)dto.TitleEng ?? DBNull.Value),
            new SqlParameter("@DescriptionGeo", (object?)dto.DescriptionGeo ?? DBNull.Value),
            new SqlParameter("@DescriptionEng", (object?)dto.DescriptionEng ?? DBNull.Value),
            new SqlParameter("@EventDate", (object?)dto.EventDate ?? DBNull.Value),
            new SqlParameter("@PartnerId", (object?)dto.PartnerId ?? DBNull.Value),
            new SqlParameter("@UpdatedBy", updatedBy),

            pIsEdited,
            pError
        );

        return new UpdateEventResult
        {
            IsEdited = (bool)pIsEdited.Value,
            Error = pError.Value as string
        };
    }
    #endregion



    #region News

    public async Task<IEnumerable<GetNewsByLanguageIdResult>> GetNewsByLanguageIdAsync(int languageId)
    {
        var languageIdParam = new SqlParameter("@LanguageID", languageId);

        return await Database.SqlQueryRaw<GetNewsByLanguageIdResult>("EXEC GetNewsByLanguageID @LanguageID", languageIdParam).ToListAsync();
    }


    public async Task<GetNewsByIdResult?> GetNewsByIdAsync(int newsId, int languageId)
    {
        var languageParam = new SqlParameter("@LanguageID", languageId);
        var newsParam = new SqlParameter("@NewsID", newsId);

        var result = await Database
    .SqlQueryRaw<GetNewsByIdResult>(
        @"EXEC dbo.GetNewsByNewsIDandLanguageID
            @LanguageID = @LanguageID,
            @NewsID = @NewsID",
        languageParam,
        newsParam)
    .ToListAsync();

return result.FirstOrDefault();
    }

    
    public async Task<AddNewsResult> AddNewsAsync(CreateNewsDto newsDto)
{
    var newsId = new SqlParameter("@NewsID", SqlDbType.Int)
    {
        Direction = ParameterDirection.Output
    };

    var newsGuid = new SqlParameter("@NewsGUID", SqlDbType.UniqueIdentifier)
    {
        Direction = ParameterDirection.Output
    };

    var isAdded = new SqlParameter("@IsAdded", SqlDbType.Bit)
    {
        Direction = ParameterDirection.Output
    };

    var error = new SqlParameter("@Error", SqlDbType.NVarChar, -1)
    {
        Direction = ParameterDirection.Output
    };

    await Database.ExecuteSqlRawAsync(
        @"EXEC dbo.AddNews
            @TitleGeo,
            @TitleEng,
            @BodyGeo,
            @BodyEng,
            @UserID,
            @NewsDate,
            @NewsID OUTPUT,
            @NewsGUID OUTPUT,
            @IsAdded OUTPUT,
            @Error OUTPUT",

        new SqlParameter("@TitleGeo", newsDto.TitleGeo),
        new SqlParameter("@TitleEng", newsDto.TitleEng),
        new SqlParameter("@BodyGeo", newsDto.BodyGeo),
        new SqlParameter("@BodyEng", newsDto.BodyEng),
        new SqlParameter("@UserID", newsDto.UserId),
        new SqlParameter("@NewsDate", newsDto.NewsDate),

        newsId,
        newsGuid,
        isAdded,
        error
    );

    return new AddNewsResult
    {
        NewsId = newsId.Value == DBNull.Value ? null : (int?)newsId.Value,
        NewsGuid = newsGuid.Value == DBNull.Value ? null : (Guid?)newsGuid.Value,
        IsAdded = isAdded.Value != DBNull.Value && (bool)isAdded.Value,
        Error = error.Value == DBNull.Value ? null : error.Value.ToString()
    };
}

public async Task<EditNewsResult> EditNewsAsync(int id, EditNewsDto newsDto, int userId)
{
    var isEdited = new SqlParameter("@IsEdited", SqlDbType.Bit)
    {
        Direction = ParameterDirection.Output
    };

    var error = new SqlParameter("@Error", SqlDbType.NVarChar, -1)
    {
        Direction = ParameterDirection.Output
    };

    await Database.ExecuteSqlRawAsync(
    @"EXEC dbo.EditNews
        @NewsID = @NewsID,
        @TitleGeo = @TitleGeo,
        @TitleEng = @TitleEng,
        @BodyGeo = @BodyGeo,
        @BodyEng = @BodyEng,
        @NewsDate = @NewsDate,
        @UserID = @UserID,
        @IsEdited = @IsEdited OUTPUT,
        @Error = @Error OUTPUT",

    new SqlParameter("@NewsID", id),
    new SqlParameter("@TitleGeo", (object?)newsDto.TitleGeo ?? DBNull.Value),
    new SqlParameter("@TitleEng", (object?)newsDto.TitleEng ?? DBNull.Value),
    new SqlParameter("@BodyGeo", (object?)newsDto.BodyGeo ?? DBNull.Value),
    new SqlParameter("@BodyEng", (object?)newsDto.BodyEng ?? DBNull.Value),
    new SqlParameter("@NewsDate", (object?)newsDto.NewsDate ?? DBNull.Value),
    new SqlParameter("@UserID", userId),

    isEdited,
    error
);

    return new EditNewsResult
    {
        IsEdited = isEdited.Value != DBNull.Value && (bool)isEdited.Value,
        Error = error.Value == DBNull.Value ? null : error.Value.ToString()
    };
}

public async Task<DeleteNewsResult> DeleteNewsAsync(int id, int userId)
{
    var isDeleted = new SqlParameter("@IsDeleted", SqlDbType.Bit)
    {
        Direction = ParameterDirection.Output
    };

    var error = new SqlParameter("@Error", SqlDbType.NVarChar, -1)
    {
        Direction = ParameterDirection.Output
    };

    await Database.ExecuteSqlRawAsync(
        @"EXEC dbo.DeleteNews
            @NewsID = @NewsID,
            @UserID = @UserID,
            @IsDeleted = @IsDeleted OUTPUT,
            @Error = @Error OUTPUT",

        new SqlParameter("@NewsID", id),
        new SqlParameter("@UserID", userId),
        isDeleted,
        error
    );

    return new DeleteNewsResult
    {
        IsDeleted = isDeleted.Value != DBNull.Value && (bool)isDeleted.Value,
        Error = error.Value == DBNull.Value ? null : error.Value.ToString()
    };
}

    #endregion



    #region Feedback
    public IQueryable<GetFeedbackResult> GetFeedback()
    {
        return Database.SqlQuery<GetFeedbackResult>($"EXEC dbo.GetFeedback");
    }

    public async Task<AddFeedbackResult> AddFeedbackAsync(
    CreateFeedbackDto dto,
    int userId)
{
    var pFeedbackId = new SqlParameter("@FeedbackID", SqlDbType.Int)
    {
        Direction = ParameterDirection.Output
    };

    var pIsAdded = new SqlParameter("@IsAdded", SqlDbType.Bit)
    {
        Direction = ParameterDirection.Output
    };

    var pError = new SqlParameter("@Error", SqlDbType.NVarChar, -1)
    {
        Direction = ParameterDirection.Output
    };

    await Database.ExecuteSqlRawAsync(
        @"EXEC dbo.AddFeedback
            @UserID,
            @Content,
            @Rating,
            @FeedbackID OUTPUT,
            @IsAdded OUTPUT,
            @Error OUTPUT",

        new SqlParameter("@UserID", userId),
        new SqlParameter("@Content", dto.Content),
        new SqlParameter("@Rating", (object?)dto.Rating ?? DBNull.Value),

        pFeedbackId,
        pIsAdded,
        pError
    );

    return new AddFeedbackResult
    {
        FeedbackID = pFeedbackId.Value == DBNull.Value
            ? null
            : (int?)pFeedbackId.Value,

        IsAdded = pIsAdded.Value != DBNull.Value &&
                  (bool)pIsAdded.Value,

        Error = pError.Value == DBNull.Value
            ? null
            : pError.Value.ToString()
    };
}


    #endregion



    #region Jobs

    
//for admin
    public IQueryable<GetJobAdvertisementsResult> GetJobAdvertisements(
    int languageId)
{
    return Database.SqlQuery<GetJobAdvertisementsResult>(
        $@"EXEC dbo.GetJobAdvertisementsByLanguageID
            @LanguageID={languageId}");
}

//for user
public IQueryable<GetJobAdvertisementsResult> GetActiveJobAdvertisements(int languageId)
{
    return Database.SqlQuery<GetJobAdvertisementsResult>(
        $@"EXEC dbo.GetActiveJobAdvertisementsByLanguageID
            @LanguageID={languageId}");
}
    
    public async Task<AddJobAdvertisementResult> AddJobAdvertisementAsync(
    CreateJobAdvertisementDto dto,
    int userId)
{
    var pAdvertisementId = new SqlParameter("@AdvertisementID", SqlDbType.Int)
    {
        Direction = ParameterDirection.Output
    };

    var pAdvertisementGuid = new SqlParameter("@AdvertisementGUID", SqlDbType.UniqueIdentifier)
    {
        Direction = ParameterDirection.Output
    };

    var pIsAdded = new SqlParameter("@IsAdded", SqlDbType.Bit)
    {
        Direction = ParameterDirection.Output
    };

    var pError = new SqlParameter("@Error", SqlDbType.NVarChar, -1)
    {
        Direction = ParameterDirection.Output
    };

    await Database.ExecuteSqlRawAsync(
        @"EXEC dbo.AddJobAdvertisement
            @AdvertisementTypeID,
            @IsAlumniAd,
            @PartnerID,
            @TitleGeo,
            @TitleEng,
            @DescriptionGeo,
            @DescriptionEng,
            @StartDate,
            @EndDate,
            @Salary,
            @UserID,
            @AdvertisementID OUTPUT,
            @AdvertisementGUID OUTPUT,
            @IsAdded OUTPUT,
            @Error OUTPUT",

        new SqlParameter("@AdvertisementTypeID", dto.AdvertisementTypeID),
        new SqlParameter("@IsAlumniAd", dto.IsAlumniAd),
        new SqlParameter("@PartnerID", (object?)dto.PartnerID ?? DBNull.Value),
        new SqlParameter("@TitleGeo", dto.TitleGeo),
        new SqlParameter("@TitleEng", dto.TitleEng),
        new SqlParameter("@DescriptionGeo", dto.DescriptionGeo),
        new SqlParameter("@DescriptionEng", dto.DescriptionEng),
        new SqlParameter("@StartDate", dto.StartDate),
        new SqlParameter("@EndDate", dto.EndDate),
        new SqlParameter("@Salary", (object?)dto.Salary ?? DBNull.Value),
        new SqlParameter("@UserID", userId),

        pAdvertisementId,
        pAdvertisementGuid,
        pIsAdded,
        pError
    );

    return new AddJobAdvertisementResult
    {
        AdvertisementID = pAdvertisementId.Value == DBNull.Value
            ? null
            : (int?)pAdvertisementId.Value,

        AdvertisementGUID = pAdvertisementGuid.Value == DBNull.Value
            ? null
            : (Guid?)pAdvertisementGuid.Value,

        IsAdded = pIsAdded.Value != DBNull.Value &&
                  (bool)pIsAdded.Value,

        Error = pError.Value == DBNull.Value
            ? null
            : pError.Value.ToString()
    };
}

public async Task<GetJobAdvertisementsResult?> GetJobAdvertisementByIdAsync(
    int languageId,
    int advertisementId)
{
    var result = await Database.SqlQuery<GetJobAdvertisementsResult>(
        $@"EXEC dbo.GetActiveJobAdvertisementsByIDandLanguageID
            @LanguageID={languageId},
            @AdvertisementID={advertisementId}")
        .ToListAsync();

    return result.SingleOrDefault();
}

public async Task<UpdateJobAdvertisementResult> UpdateJobAdvertisementAsync(
    int advertisementId,
    UpdateJobAdvertisementDto dto,
    int userId)
{
    var pIsEdited = new SqlParameter("@IsEdited", SqlDbType.Bit)
    {
        Direction = ParameterDirection.Output
    };

    var pError = new SqlParameter("@Error", SqlDbType.NVarChar, -1)
    {
        Direction = ParameterDirection.Output
    };

    await Database.ExecuteSqlRawAsync(
        @"EXEC dbo.EditJobAdvertisement
            @AdvertisementID,
            @AdvertisementTypeID,
            @IsAlumniAd,
            @PartnerID,
            @TitleGeo,
            @TitleEng,
            @DescriptionGeo,
            @DescriptionEng,
            @StartDate,
            @EndDate,
            @Salary,
            @UserID,
            @IsEdited OUTPUT,
            @Error OUTPUT",

        new SqlParameter("@AdvertisementID", advertisementId),
        new SqlParameter("@AdvertisementTypeID", dto.AdvertisementTypeID),
        new SqlParameter("@IsAlumniAd", dto.IsAlumniAd),
        new SqlParameter("@PartnerID", (object?)dto.PartnerID ?? DBNull.Value),
        new SqlParameter("@TitleGeo", (object?)dto.TitleGeo ?? DBNull.Value),
        new SqlParameter("@TitleEng", (object?)dto.TitleEng ?? DBNull.Value),
        new SqlParameter("@DescriptionGeo", (object?)dto.DescriptionGeo ?? DBNull.Value),
        new SqlParameter("@DescriptionEng", (object?)dto.DescriptionEng ?? DBNull.Value),
        new SqlParameter("@StartDate", (object?)dto.StartDate ?? DBNull.Value),
        new SqlParameter("@EndDate", (object?)dto.EndDate ?? DBNull.Value),
        new SqlParameter("@Salary", (object?)dto.Salary ?? DBNull.Value),
        new SqlParameter("@UserID", userId),

        pIsEdited,
        pError
    );

    return new UpdateJobAdvertisementResult
    {
        IsEdited = pIsEdited.Value != DBNull.Value && (bool)pIsEdited.Value,
        Error = pError.Value == DBNull.Value ? null : pError.Value.ToString()
    };
}

public async Task<DeleteJobAdvertisementResult> DeleteJobAdvertisementAsync(
    int advertisementId,
    int userId)
{
    var pIsDeleted = new SqlParameter("@IsDeleted", SqlDbType.Bit)
    {
        Direction = ParameterDirection.Output
    };

    var pError = new SqlParameter("@Error", SqlDbType.NVarChar, -1)
    {
        Direction = ParameterDirection.Output
    };

    await Database.ExecuteSqlRawAsync(
        @"EXEC dbo.DeleteJobAdvertisement
            @AdvertisementID,
            @UserID,
            @IsDeleted OUTPUT,
            @Error OUTPUT",

        new SqlParameter("@AdvertisementID", advertisementId),
        new SqlParameter("@UserID", userId),

        pIsDeleted,
        pError
    );

    return new DeleteJobAdvertisementResult
    {
        IsDeleted = pIsDeleted.Value != DBNull.Value &&
                    (bool)pIsDeleted.Value,

        Error = pError.Value == DBNull.Value
            ? null
            : pError.Value.ToString()
    };
}
    
    #endregion

}