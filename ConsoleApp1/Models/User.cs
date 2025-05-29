namespace TaskManager.Models;

public class User
{
    public string UserName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public override string ToString() => $"{UserName}({Email})";

}


//Traditional way
//public class User
//{
//    string UserName { get; }
//    string Email { get; }
//    User(string username, string email)
//    {
//        UserName = username;
//        Email=email;
//    }
//public override string ToString() => $"{UserName}({Email})";
//}