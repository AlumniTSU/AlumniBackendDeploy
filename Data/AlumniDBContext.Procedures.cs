using Microsoft.EntityFrameworkCore;
using backend.Results;
using backend.Dtos.Event;
using System.Data;
using Microsoft.Data.SqlClient;
using backend.Dtos.File;

namespace backend.Entities;

public partial class AlumniDBContext
{
    public IQueryable<GetEventsResult> GetEvents() => Database.SqlQuery<GetEventsResult>($"EXEC dbo.GetEvents");

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
}