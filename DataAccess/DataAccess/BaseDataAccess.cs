using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System;
using DataAccess.Interfaces;

namespace DataAccess.DataAccess
{
    public abstract class BaseDataAccess<T> : IBaseDataAccess<T> where T : class
    {
        private readonly string _connectionstring;
        private string ValueNames => string.Join(", ", Values.ToList().Select(property => property.Trim()));
        private string ValueParameters => string.Join(", ", Values.ToList().Select(property => $"@{property.Trim()}"));
        private string ValueUpdates => string.Join(", ", Values.ToList().Select(property => $"{property.Trim()}=@{property.Trim()}"));

        protected BaseDataAccess(string connectionstring)
        {
            TableName = typeof(T).Name;
            Values = typeof(T).GetProperties().Where(property => property.Name != "Id").Select(property => property.Name);
            _connectionstring = connectionstring;
        }
        protected IDbConnection CreateConnection() => new SqlConnection(_connectionstring);
        protected string TableName { get; set; }
        protected IEnumerable<string> Values { get; set; }

        public async Task<int> CreateAsync(T entity)
        {
            string command = $"INSERT INTO [{TableName}] ({ValueNames}) OUTPUT INSERTED.Id VALUES ({ValueParameters});";
            try
            {
                using var connection = CreateConnection();
                return await connection.QuerySingleAsync<int>(command, entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during async creation of '{typeof(T).Name}'!\nMessage was: '{ex.Message}'\nTable Name: {TableName}\nValueNames: {ValueNames}\nCommand: {command}", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            string command = $"SELECT * FROM [{TableName}];";
            try
            {
                using var connection = CreateConnection();
                return await connection.QueryAsync<T>(command);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all async of '{typeof(T).Name}'!\nMessage was: '{ex.Message}'\nTable Name: {TableName}\nValueNames: {ValueNames}\nCommand: {command}", ex);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            string command = $"SELECT * FROM [{TableName}] WHERE Id=@Id;";
            try
            {
                using var connection = CreateConnection();
                return await connection.QuerySingleAsync<T>(command, new { Id=id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting asyng by Id:`{id}` of '{typeof(T).Name}'!\nMessage was: '{ex.Message}'\nTable Name: {TableName}\nValueNames: {ValueNames}\nCommand: {command}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string command = $"DELETE FROM [{TableName}] WHERE Id=@Id;";
            try
            {
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(command, new { Id = id }) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during async deletion of '{typeof(T).Name}' with Id:{id}!\nMessage was: '{ex.Message}'\nTable Name: {TableName}\nCommand: {command}", ex);
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            string command = $"UPDATE [{TableName}] SET {ValueUpdates} WHERE Id=@Id;";
            try
            {
                using var connection = CreateConnection();
                return await connection.ExecuteAsync(command, entity) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during async update of '{typeof(T).Name}'!\nMessage was: '{ex.Message}'\nTable Name: {TableName}\nValueNames: {ValueNames}\nCommand: {command}", ex);
            }
        }
    }
}
