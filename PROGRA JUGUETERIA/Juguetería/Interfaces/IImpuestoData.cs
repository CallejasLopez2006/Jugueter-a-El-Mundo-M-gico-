using System.Collections.Generic;
using System.Threading.Tasks;

namespace Juguetería.Entity.Interfaces
{
    public interface IImpuestoData
    {
        Task<IEnumerable<Impuesto>> GetAllAsync();
        Task<Impuesto?> GetByIdAsync(int id);
        Task AddAsync(Impuesto impuesto);
        Task UpdateAsync(Impuesto impuesto);
        Task DeleteAsync(int id);
    }
}