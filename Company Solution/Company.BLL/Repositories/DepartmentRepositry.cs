using Company.BLL.Interfaces;
using Company.DAL.Data.Contexts;
using Company.DAL.Models;

namespace Company.BLL.Repositories
{
    public class DepartmentRepositry : IDepartmentRespository
    {
        private readonly AppDbContext _context;

        public DepartmentRepositry(AppDbContext context) // Ask CLR to Create Object From AppDbContext
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department Get(int id)
        {
            //return _context.Departments.FirstOrDefault(D => D.Id == id);
            return _context.Departments.Find(id);
        }

        public int Add(Department entity)
        {
            _context.Departments.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(Department entity)
        {
            _context.Departments.Update(entity);
            return _context.SaveChanges();

        }

        public int Delete(Department entity)
        {
            _context.Departments.Remove(entity);
            return _context.SaveChanges();
        }
    }
}
