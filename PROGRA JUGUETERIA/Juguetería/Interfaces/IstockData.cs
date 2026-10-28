using System.Collections.Generic;
using System.Threading.Tasks;

namespace Juguetería.Entity.Interfaces
{
    public interface IStockData
    {
        Task<IEnumerable<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task AddAsync(Stock stock);
        Task UpdateAsync(Stock stock);
        Task DeleteAsync(int id);
    }
}