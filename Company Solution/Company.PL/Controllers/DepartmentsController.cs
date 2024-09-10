using Company.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.PL.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRespository _departmentRepositry;

        public DepartmentsController(IDepartmentRespository departmentRepositry) // Ask CLR to Create object from DepartmentRepositry
        {
            _departmentRepositry = departmentRepositry;
        }

        public IActionResult Index()
        {
            var departments = _departmentRepositry.GetAll();
            return View(departments);
        }
    }
}
