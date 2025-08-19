namespace ChatServer
{
    public class AuthService
    {
        private readonly ChatDbContext _db;

        public AuthService(ChatDbContext db)
        {
            _db = db;
        }

        public bool Register(string username, string password)
        {
            if(_db.Users.Any(u=>u.Username == username)) 
                return false;

            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            _db.Users.Add(new User() { Username = username, PasswordHash = hash });
            _db.SaveChanges();

            return true;
        }

        public bool Login(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return false;

            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
    }
}
