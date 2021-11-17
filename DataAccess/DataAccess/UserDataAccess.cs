using Dapper;
using DataAccess.Interfaces;
using DataAccess.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.DataAccess
{
    public class UserDataAccess : BaseDataAccess<UserDataAccess>, IUserDataAccess
    {
        public UserDataAccess(string connectionstring) : base(connectionstring)
        {
        }

        public async Task<int> LoginAsync(User user)
        {
           try
            {
                var query = "SELECT id, password_hash_salt FROM [User] WHERE email=@Email";
                using var connection = CreateConnection();
                var userTuple = await connection.QuerySingleAsync<UserTuple>(query, new { Email = user.Email });
                //we don't check if userTuple is null because the async query always returns an object.
                if (BCryptTool.VerifyPassword(user.Password, userTuple.Password_hash_salt))
                {
                    return userTuple.Id;
                }
                return -1;
            }
            catch(Exception ex)
            {
                //this would throw an exception when the password is wrong but the email is correct
                //throw new Exception($"Error trying to login with email {user.Email}: '{ex.Message}'.", ex);
                //we would rather return -1 again as not specifying which of the credentials is wrong
                //provides more security
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
