using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Authentication
{
    public static class BCryptTool
    {
        private const int saltRounds = 13;
        //TODO: consider deleting GetSalt later on
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, saltRounds);
        }
        public static bool VerifyPassword(string password,string passwordHashSalt)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHashSalt);
        }
    }
}
