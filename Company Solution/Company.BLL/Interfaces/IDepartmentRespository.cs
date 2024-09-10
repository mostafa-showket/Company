using Company.DAL.Models;

namespace Company.BLL.Interfaces
{
    public interface IDepartmentRespository
    {
        IEnumerable<Department> GetAll();
        Department Get(int id);
        int Add(Department entity);
        int Update(Department entity);
        int Delete(Department entity);
    }
}
