using Company.DAL.Models;

namespace Company.BLL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetByName(string name);
    }
}
