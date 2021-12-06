using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System;
using DataAccess.Interfaces;
using System.ComponentModel;

namespace DataAccess.DataAccess
{
    public abstract class BaseDataAccess<T> : IBaseDataAccess<T> where T : class
    {
        private readonly string _connectionstring;
        // ValueNames = "total_price, date"
        private string ValueNames => string.Join(", ", Values.ToList().Select(property => property.Trim()));
        // ValueParameters = "@total_price, @date"
        private string ValueParameters => string.Join(", ", RawValues.ToList().Select(property => $"@{property.Trim()}"));
        // ValueUpdates = "total_price=@total_price, date=@date"
        private string ValueUpdates => string.Join(", ", RawValues.ToList().Select(property => $"{property.Trim()}=@{property.Trim()}"));

        protected BaseDataAccess(string connectionstring)
        {
            // Sets TableName to the class' name e.g. 'TableName = "Booking"'
            TableName = typeof(T).Name;
            // List of the names of the class' properties 'total_price, date'
            RawValues = typeof(T).GetProperties().Where(property => property.Name != "Id").Select(property => property.Name);
            Values = RawValues;
            _connectionstring = connectionstring;
            // Map properties with [Description(...)] attribute on the model
            // TotalPrice => total_price
            var map = new CustomPropertyTypeMap(typeof(T),
            (type, columnName) => type.GetProperties().FirstOrDefault(prop =>
            {
                if (prop == null) return false;
                var attrib = (DescriptionAttribute)Attribute.GetCustomAttribute(prop, typeof(DescriptionAttribute), false);
                return (attrib?.Description ?? prop.Name).ToLower() == columnName.ToLower();
            }));
            SqlMapper.SetTypeMap(typeof(T), map);
        }
        protected IDbConnection CreateConnection() => new SqlConnection(_connectionstring);
        protected string TableName { get; set; }
        // Values = total_price, date
        protected IEnumerable<string> Values { get; set; }
        // RawValues = TotalPrice, Date
        protected IEnumerable<string> RawValues;

        public virtual async Task<int> CreateAsync(T entity)
        {
                            // INSERT INTO [Booking] (total_price, date) OUTPUT INSERTED.Id VALUES (@TotalPrice, @Date)
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

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
                            // SELECT * FROM [Booking];
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

        public virtual async Task<T> GetByIdAsync(int id)
        {
                            // SELECT * FROM [Booking] WHERE Id=@Id;
            string command = $"SELECT * FROM [{TableName}] WHERE Id=@Id;";
            try
            {
                using var connection = CreateConnection();
                return await connection.QueryFirstOrDefaultAsync<T>(command, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting asyng by Id:`{id}` of '{typeof(T).Name}'!\nMessage was: '{ex.Message}'\nTable Name: {TableName}\nValueNames: {ValueNames}\nCommand: {command}", ex);
            }
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
                            // DELETE FROM [Booking] WHERE Id=@Id;
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

        public virtual async Task<bool> UpdateAsync(T entity)
        {
                            // UPDATE [Booking] SET total_price=@total_price, date=@date WHERE Id=@Id;
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
