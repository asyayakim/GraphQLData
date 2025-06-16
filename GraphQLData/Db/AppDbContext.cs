using GraphQLData.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLData.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions
        <AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<UserResult> Users { get; set; }
}