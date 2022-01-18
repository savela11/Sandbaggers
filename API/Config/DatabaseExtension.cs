using Microsoft.EntityFrameworkCore;

namespace API.Config;

public static class DatabaseExtension
{
    public static void ConnectToDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PGSQLConnection")));
    }
}