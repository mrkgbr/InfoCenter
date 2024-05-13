using Microsoft.EntityFrameworkCore;

namespace InfoCenter.Api.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<InfoCenterContext>();
        dbContext.Database.Migrate();
    }
}