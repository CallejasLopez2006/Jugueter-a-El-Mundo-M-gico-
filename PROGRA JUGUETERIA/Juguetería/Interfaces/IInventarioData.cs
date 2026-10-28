using System.Collections.Generic;
using System.Threading.Tasks;

namespace Juguetería.Entity.Interfaces
{
    public interface IInventarioData
    {
        Task<IEnumerable<Inventario>> GetAllAsync();
        Task<Inventario?> GetByIdAsync(int id);
        Task AddAsync(Inventario inventario);
        Task UpdateAsync(Inventario inventario);
        Task DeleteAsync(int id);
    }
}