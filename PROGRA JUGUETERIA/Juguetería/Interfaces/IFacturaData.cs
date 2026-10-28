using System.Collections.Generic;
using System.Threading.Tasks;

namespace Juguetería.Entity.Interfaces
{
    public interface IFacturasData
    {
        Task<IEnumerable<Facturas>> GetAllAsync();
        Task<Facturas?> GetByIdAsync(int id);
        Task AddAsync(Facturas factura);
        Task UpdateAsync(Facturas factura);
        Task DeleteAsync(int id);
    }
}