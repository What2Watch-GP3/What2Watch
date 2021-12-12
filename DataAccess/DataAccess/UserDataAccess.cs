using Dapper;
using DataAccess.Interfaces;
using DataAccess.Authentication;
using System.Threading.Tasks;
using DataAccess.Models;
using System.Linq;

namespace DataAccess.DataAccess
{
    public class UserDataAccess : BaseDataAccess<User>, IUserDataAccess
    {
        public UserDataAccess(string connectionstring) : base(connectionstring) {}

        public async Task<User> LoginAsync(User user)
        {
            try
            {
                var query = "SELECT * FROM [User] WHERE email=@Email";
                using var connection = CreateConnection();
                var userResult = await connection.QuerySingleAsync<User>(query, new { user.Email });
                if (BCryptTool.VerifyPassword(user.Password, userResult.Password))
                {
                    return userResult;
                }
                return null;
            }
            catch
            {
                //TODO: throw a more specific exception
                return null;
                //throw new Exception(ex.Message, ex);
            }
        }
    }
}
