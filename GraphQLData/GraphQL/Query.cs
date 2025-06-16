using GraphQLData.Models;
using GraphQLData.Services;

namespace GraphQLData.GraphQL;

public class Query
{
    public async Task<UserResult?> GetRandomUser([Service] UserService userService)
    {
        return await userService.GetRandomUserAsync();
    }
}