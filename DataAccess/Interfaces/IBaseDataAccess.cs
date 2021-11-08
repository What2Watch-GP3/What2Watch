using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
  
        public interface IBaseDataAccess<T>
        {
            Task<int> CreateAsync(T entity);
            Task<IEnumerable<T>> GetAllAsync();
            Task<T> GetByIdAsync(int id);
            Task<bool> DeleteAsync(int id);
            Task<bool> UpdateAsync(T entity);
        }
    
}
