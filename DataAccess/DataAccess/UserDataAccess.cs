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
                if (BCryptTool.VerifyPassword(user.Password, userTuple.password_hash_salt))
                {
                    return userTuple.id;
                }
                return -1;
            }
            catch(Exception ex)
            {
                //TODO: throw a more specific exception
                return -1;
                //throw new Exception(ex.Message, ex);
            }
        }
    }
    internal class UserTuple
    {
        public int id;
        public string password_hash_salt;
    }

}
