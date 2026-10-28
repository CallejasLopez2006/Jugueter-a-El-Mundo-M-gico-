using System.Collections.Generic;
using System.Threading.Tasks;

namespace Juguetería.Entity.Interfaces
{
    public interface IDetalle_CompraData
    {
        Task<IEnumerable<Detalle_Compra>> GetAllAsync();
        Task<Detalle_Compra> GetByIdAsync(int id);
        Task AddAsync(Detalle_Compra detalleCompra);
        Task UpdateAsync(Detalle_Compra detalleCompra);
        Task DeleteAsync(int id);
    }
}