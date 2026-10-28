using System.Collections.Generic;
using System.Threading.Tasks;

namespace Juguetería.Entity.Interfaces
{
    public interface IEmpleadoData
    {
        Task<IEnumerable<Empleado>> GetAllAsync();
        Task<Empleado> GetByIdAsync(int id);
        Task AddAsync(Empleado empleado);
        Task UpdateAsync(Empleado empleado);
        Task DeleteAsync(int id);
    }
}