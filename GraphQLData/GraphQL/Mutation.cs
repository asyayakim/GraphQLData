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
       var user =await userService.GetRandomUserAsync();
       if (user == null || user.Name == null || user.Picture == null)
       {
           throw new Exception("User data is incomplete or null.");
       }


       user.Id = Guid.NewGuid();
       user.Name.NameId = Guid.NewGuid();
       user.Picture.PictureId = Guid.NewGuid();

       user.NameId = user.Name.NameId;
       user.PictureId = user.Picture.PictureId;
       
        context.Names.Add(user.Name);
        context.Pictures.Add(user.Picture);
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }
}