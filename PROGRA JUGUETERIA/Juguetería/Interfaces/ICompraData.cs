using System.Collections.Generic;
using System.Threading.Tasks;

namespace Juguetería.Entity.Interfaces
{
    public interface ICompraData
    {
        Task<IEnumerable<Compra>> GetAllAsync();
        Task<Compra> GetByIdAsync(int id);
        Task AddAsync(Compra compra);
        Task UpdateAsync(Compra compra);
        Task DeleteAsync(int id);
    }
}