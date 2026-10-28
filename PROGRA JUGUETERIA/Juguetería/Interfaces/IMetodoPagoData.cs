using System.Collections.Generic;
using System.Threading.Tasks;

namespace Juguetería.Entity.Interfaces
{
    public interface IMetodoPagoData
    {
        Task<IEnumerable<MetodoPago>> GetAllAsync();
        Task<MetodoPago?> GetByIdAsync(int id);
        Task AddAsync(MetodoPago metodoPago);
        Task UpdateAsync(MetodoPago metodoPago);
        Task DeleteAsync(int id);
    }
}