using Microsoft.EntityFrameworkCore;
using backend.Results;
using backend.Dtos.Event;
using System.Data;
using Microsoft.Data.SqlClient;

using backend.Dtos.File;
using backend.Dtos.News;
using backend.Results.News;

namespace backend.Entities;

public partial class AlumniDBContext
{
    #region Events
    public IQueryable<GetEventsResult> GetEvents(int languageId) => Database.SqlQuery<GetEventsResult>($"EXEC dbo.GetEventsByLanguageID @LanguageID={languageId}");

    public async Task<GetEventsResult?> GetEventByLanguageIdAndEventIdAsync(int languageId, int eventId)
    {
        var result = await Database.SqlQuery<GetEventsResult>($"EXEC GetEventsByLanguageIDAndEVentID @LanguageID={languageId}, @EventID={eventId}").ToListAsync();

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
            @CategoryID,
            @TitleGeo,
            @TitleEng,
            @BodyGeo,
            @BodyEng,
            @SlugGeo,
            @SlugEng,
            @UserID,
            @NewsDate,
            @NewsID OUTPUT,
            @NewsGUID OUTPUT,
            @IsAdded OUTPUT,
            @Error OUTPUT",

        new SqlParameter("@CategoryID", newsDto.CategoryId),
        new SqlParameter("@TitleGeo", newsDto.TitleGeo),
        new SqlParameter("@TitleEng", newsDto.TitleEng),
        new SqlParameter("@BodyGeo", newsDto.BodyGeo),
        new SqlParameter("@BodyEng", newsDto.BodyEng),
        new SqlParameter("@SlugGeo", newsDto.SlugGeo),
        new SqlParameter("@SlugEng", newsDto.SlugEng),
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


    #endregion
}