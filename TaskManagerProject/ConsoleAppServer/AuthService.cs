using BCrypt.Net;
using ConsoleAppServer;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

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
    public static async Task<string> LoginAsync(string username, string password)
    {
        using (var db = new TaskManagerEntities())
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.username == username);

            if (user == null)
                return "NOT_FOUND";

            bool valid = BCrypt.Net.BCrypt.Verify(password, user.hash_passowrd);

            if (!valid)
                return "WRONG_PASSWORD";

            return $"SUCCESS|{user.Id}|{user.username}|{user.lvl_security}";
        }
    }
    public static async Task<string> RegisterAsync(string username, string password, string email)
    {
        using (var db = new TaskManagerEntities())
        {
            var exists = await db.Users.AnyAsync(u => u.username == username);

            if (exists)
                return "USER_EXISTS";

            string hash = BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);

            var user = new Users
            {
                username = username,
                hash_passowrd = hash,
                email = email,
                lvl_security = 1
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return "SUCCESS";
        }
    }
}