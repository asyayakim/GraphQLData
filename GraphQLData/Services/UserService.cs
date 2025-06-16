using GraphQLData.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLData.Services;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserResult?> GetRandomUserAsync()
    {
        var response = await _httpClient.
            GetFromJsonAsync<RandomUserResponse>("https://randomuser.me/api");
        if (response == null)
        { 
            throw new ArgumentException("No response from API");
        }
        return  response.Results.FirstOrDefault();
    }
}
