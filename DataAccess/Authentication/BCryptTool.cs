namespace DataAccess.Authentication
{
    public static class BCryptTool
    {
        private const int saltRounds = 13;
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, saltRounds);
        }
        public static bool VerifyPassword(string password, string passwordHashSalt)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHashSalt);
        }
    }
}
