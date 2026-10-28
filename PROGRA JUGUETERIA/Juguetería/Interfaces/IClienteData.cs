using System.Collections.Generic;
using System.Threading.Tasks;

namespace Juguetería.Entity.Interfaces
{
    public interface IClienteData
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}