using Dapper;
using DataAccess.Interfaces;
using DataAccess.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class UserDataAccess : BaseDataAccess<UserDataAccess>, IUserDataAccess
    {
        public UserDataAccess(string connectionstring) : base(connectionstring)
        {
        }

        public async Task<int> LoginAsync(string email, string password)
        {
           try
            {
            var query = "SELECT id, password_hash_salt FROM [User] WHERE email=@Email";
                using var connection = CreateConnection();
                var userTuple = await connection.QuerySingleAsync<UserTuple>(query, new { Email = email });
                if (BCryptTool.VerifyPassword(password, userTuple.Password_hash_salt))
                {
                    return userTuple.Id;
                }
                return -1;
            }
            catch(Exception ex)
           {
                //TODO: throw a more specific exception
                // throw new Exception(ex.Message, ex);
                return -1;
           }
        }
    }
    internal class UserTuple
    {
        public int Id;
        public string Password_hash_salt;
    }
}
