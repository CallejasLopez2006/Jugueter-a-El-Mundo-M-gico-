using System.Collections.Generic;
using System.Threading.Tasks;

namespace Juguetería.Entity.Interfaces
{
    public interface IMarcaData
    {
        Task<IEnumerable<Marca>> GetAllAsync();
        Task<Marca?> GetByIdAsync(int id);
        Task AddAsync(Marca marca);
        Task UpdateAsync(Marca marca);
        Task DeleteAsync(int id);
    }
}