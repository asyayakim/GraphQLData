using GraphQLData.Db;
using GraphQLData.GraphQL.Inputs;
using GraphQLData.Models;
using GraphQLData.Services;

namespace GraphQLData.GraphQL;

public class Mutation
{
    public async Task<UserResult> AddUser([Service]UserService userService,
        [Service]AppDbContext  context)
    {
       var input = userService.GetRandomUserAsync();
        var name = new Name
        {
            NameId = Guid.NewGuid(),
            Title = input.Result.Name.Title,
            First = input.Result.Name.First,
            Last = input.Result.Name.Last,
        };
        var picture = new Picture
        {
            PictureId = Guid.NewGuid(),
            Large = input.Result.Picture.Large,
            Medium = input.Result.Picture.Medium,
            Thumbnail = input.Result.Picture.Thumbnail
        };

        var user = new UserResult
        {
            Id = Guid.NewGuid(),
            Gender = input.Result.Gender,
            Email = input.Result.Email,
            Name = name,
            NameId = name.NameId,
            Picture = picture,
            PictureId = picture.PictureId
        };
        context.Users.Add(user);
        context.Pictures.Add(picture);
        context.Names.Add(name);
        await context.SaveChangesAsync();
        return user;
    }
}