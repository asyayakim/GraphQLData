using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GraphQLData.Models;

public class RandomUserResponse
{
    public required List<UserResult> Results { get; set; }
}

public class UserResult
{
    [Key]
    
    [JsonIgnore]
    public Guid Id { get; set; }
    
    public string Gender { get; set; }
    
    [JsonIgnore]
    public Guid NameId { get; set; }
    public Name Name { get; set; }
    public string Email { get; set; }
    
    [JsonIgnore]
    public Guid PictureId { get; set; }
    public Picture Picture { get; set; }
}

public class Picture
{
    [Key]
    
    [JsonIgnore]
    public Guid PictureId { get; set; }
    public string Large {get; set;}
    public string Medium {get; set;}
    public string Thumbnail {get; set;}
}
public class Name
{
    
    [JsonIgnore]
    public Guid NameId { get; set; }
    public string Title { get; set; }
    public string First { get; set; }
    public string Last { get; set; }
}
    
