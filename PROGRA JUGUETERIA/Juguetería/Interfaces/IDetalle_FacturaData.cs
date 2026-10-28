using System.Collections.Generic;
using System.Threading.Tasks;

namespace Juguetería.Entity.Interfaces
{
    public interface IDetalle_FacturaData
    {
        Task<IEnumerable<Detalle_Factura>> GetAllAsync();
        Task<Detalle_Factura> GetByIdAsync(int id);
        Task AddAsync(Detalle_Factura detalleFactura);
        Task UpdateAsync(Detalle_Factura detalleFactura);
        Task DeleteAsync(int id);
    }
}