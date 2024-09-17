using Company.BLL.Interfaces;
using Company.DAL.Data.Contexts;
using Company.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Employee> GetByName(string name)
        {
            return _context.Employees.Where(E => E.Name.ToLower().Contains(name.ToLower())).Include(E => E.WorkFor).ToList();
        }
    }
}
