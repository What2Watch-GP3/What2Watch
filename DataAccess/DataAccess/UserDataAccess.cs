using Dapper;
using DataAccess.Interfaces;
using DataAccess.Authentication;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.DataAccess
{
    public class UserDataAccess : BaseDataAccess<UserDataAccess>, IUserDataAccess
    {
        public UserDataAccess(string connectionstring) : base(connectionstring) { }

        public async Task<int> LoginAsync(User user)
        {
            try
            {
                var query = "SELECT id, password_hash_salt AS Password FROM [User] WHERE email=@Email";
                using var connection = CreateConnection();
                var userResult = await connection.QuerySingleAsync<User>(query, new { user.Email });
                if (BCryptTool.VerifyPassword(user.Password, userResult.Password))
                {
                    return userResult.Id;
                }
                return -1;
            }
            catch
            {
                //TODO: throw a more specific exception
                return -1;
                //throw new Exception(ex.Message, ex);
            }
        }
    }
}
