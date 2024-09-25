using System;
using Microsoft.EntityFrameworkCore;

namespace VideoGame.Api.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider serviceProv)
    {
        using var scope = serviceProv.CreateScope();
        //service scope to use to start resolving services
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate(); //auto apply missing migrations into db on mssql
    }
}
