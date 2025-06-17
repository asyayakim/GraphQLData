using GraphQLData.Db;
using GraphQLData.GraphQL;
using GraphQLData.Services;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<UserService>();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(builder.
        Configuration.
        GetConnectionString("DefaultConnection")));
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);
builder.Services.AddRouting();

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints?.MapGraphQL();
});
app.UseVoyager(new VoyagerOptions()
    {
        Path = "/voyager",
        QueryPath = "/graphql"
    }
);
app.MapGet("/", () => "Navigate to /graphql for GraphQL endpoint");

app.Run();
