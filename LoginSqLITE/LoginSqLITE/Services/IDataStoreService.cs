using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoginSqLITE.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddAsync(T value);
        Task<bool> UpdateAsync(T value);
        Task<bool> DeleteAsync(T value);
        Task<T> GetByIdAsync(int value);
        Task<List<T>> GetAllAsync(bool forceRefresh = false);
    }
}
