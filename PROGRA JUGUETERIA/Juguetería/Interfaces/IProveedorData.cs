using System.Collections.Generic;
using System.Threading.Tasks;

namespace Juguetería.Entity.Interfaces
{
    public interface IProveedorData
    {
        Task<IEnumerable<Proveedor>> GetAllAsync();
        Task<Proveedor> GetByIdAsync(int id);
        Task AddAsync(Proveedor proveedor);
        Task UpdateAsync(Proveedor proveedor);
        Task DeleteAsync(int id);
    }
}