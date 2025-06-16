using GraphQLData.GraphQL;
using GraphQLData.Models;
using GraphQLData.Services;
using HotChocolate.AspNetCore.Voyager;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<UserService>();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();
builder.Services.AddRouting();

var app = builder.Build();
//app.MapGraphQL();
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
