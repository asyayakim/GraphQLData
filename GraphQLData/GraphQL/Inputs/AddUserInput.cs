namespace GraphQLData.GraphQL.Inputs;

public class AddUserInput
{
    public string Gender { get; set; }
    public string Email { get; set; }

    public NameInput Name { get; set; }
    public PictureInput Picture { get; set; }
}

public class NameInput
{
    public string Title { get; set; }
    public string First { get; set; }
    public string Last { get; set; }
}

public class PictureInput
{
    public string Large { get; set; }
    public string Medium { get; set; }
    public string Thumbnail { get; set; }
}