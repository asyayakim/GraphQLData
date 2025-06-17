using GraphQLData.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UnitTests;

public class ConnectionTest
{
    [Fact]
    public void TestDbConnection()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection")                    ?? throw new InvalidOperationException("Connection string not found.");

        optionsBuilder.UseNpgsql(connectionString);
        Assert.False(string.IsNullOrEmpty(connectionString));
    }

}