using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Text;

namespace DataAccess.DataAccess
{
    public abstract class BaseDataAccess<T> where T : class
    {
        private readonly string _connectionstring;

        protected string TableName => typeof(T).Name;
        protected string ValueNames => string.Join(", ", typeof(T).GetProperties().Where(property => property.Name != "Id").ToList().Select(property => property.Name.Trim()));
        public static string ValueParameters => string.Join(", ", (typeof(T).GetProperties()).Where(property => property.Name != "Id").ToList().Select(property => $"@property.Name.Trim()"));
        public static string ValueUpdates => string.Join(", ", (typeof(T).GetProperties()).Where(property => property.Name != "Id").ToList().Select(property => $"{property.Name.Trim()}=@{property.Name.Trim()}"));
        protected BaseDataAccess(string connectionstring) => _connectionstring = connectionstring;
        protected IDbConnection CreateConnection() => new SqlConnection(_connectionstring);

        public async Task<int> CreateAsync(T entity)
        {
            string command = $"INSERT INTO [{TableName}] ({ValueNames}) OUTPUT INSERTED.Id VALUES ({ValueParameters});";
            return await CreateConnection().QuerySingleAsync<int>(command, entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            string command = $"SELECT * FROM [{TableName}];";
            return await CreateConnection().QueryAsync<T>(command);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            string command = $"SELECT * FROM [{TableName}] WHERE Id=@Id;";
            return await CreateConnection().QuerySingleAsync<T>(command, new { Id=id });
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string command = $"DELETE FROM [{TableName}] WHERE Id=@Id;";
            return await CreateConnection().ExecuteAsync(command, new { Id = id }) > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            string command = $"UPDATE [{TableName}] SET {ValueUpdates} WHERE Id=@Id;";
            return await CreateConnection().ExecuteAsync(command, entity) > 0;
        }
    }
}
