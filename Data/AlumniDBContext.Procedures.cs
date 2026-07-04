using Microsoft.EntityFrameworkCore;
using backend.Results;

namespace backend.Entities;

public partial class AlumniDBContext
{
    public IQueryable<GetEventsResult> GetEvents() => Database.SqlQuery<GetEventsResult>($"EXEC dbo.GetEvents");
}