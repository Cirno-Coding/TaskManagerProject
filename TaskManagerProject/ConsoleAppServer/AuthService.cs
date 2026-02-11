using BCrypt.Net;
using ConsoleAppServer;
using System.Linq;

public static class AuthService
{
    public static string Login(string username, string password)
    {
        using (var db = new TaskManagerEntities())
        {
            var user = db.Users.FirstOrDefault(u => u.username == username);

            if (user == null)
                return "NOT_FOUND";

            bool isValid = BCrypt.Net.BCrypt.Verify(password, user.hash_passowrd);

            if (!isValid)
                return "WRONG_PASSWORD";

            return "SUCCESS";
        }
    }
}