namespace GraphQLData.Models;

public class RandomUserResponse
{
    public List<UserResult?> Results { get; set; }
}

public class UserResult
{
    public string Gender { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
