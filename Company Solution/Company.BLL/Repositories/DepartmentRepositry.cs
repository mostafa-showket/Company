using Company.BLL.Interfaces;
using Company.DAL.Data.Contexts;
using Company.DAL.Models;

namespace Company.BLL.Repositories
{
    public class DepartmentRepositry : GenericRepository<Department>, IDepartmentRespository
    {
        public DepartmentRepositry(AppDbContext context) : base(context)// Ask CLR to Create Object From AppDbContext
        {
        }
    }
}
