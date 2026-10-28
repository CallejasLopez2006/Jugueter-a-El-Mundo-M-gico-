using System.Collections.Generic;
using System.Threading.Tasks;

namespace Juguetería.Entity.Interfaces
{
    public interface IEdadData
    {
        Task<IEnumerable<Edad>> GetAllAsync();
        Task<Edad> GetByIdAsync(int id);
        Task AddAsync(Edad edad);
        Task UpdateAsync(Edad edad);
        Task DeleteAsync(int id);
    }
}