using Company.BLL.Interfaces;
using Company.BLL.Repositories;
using Company.DAL.Data.Contexts;

namespace Company.BLL
{
    public class UnitOfWork : IUnitOfwork
    {
        private readonly AppDbContext _context;
        private IEmployeeRepository _employeeRepository;
        private IDepartmentRespository _departmentRespository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _employeeRepository = new EmployeeRepository(context);
            _departmentRespository = new DepartmentRepositry(context);
        }

        public IEmployeeRepository EmployeeRepository => _employeeRepository;

        public IDepartmentRespository DepartmentRespository => _departmentRespository;
    }
}
