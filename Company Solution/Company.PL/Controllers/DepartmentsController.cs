using Company.BLL.Interfaces;
using Company.DAL.Models;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department model)
        {
            if (ModelState.IsValid)
            {
                var Count = _departmentRepositry.Add(model);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest(); // 400
            var department = _departmentRepositry.Get(id.Value);

            if (department is null) return NotFound(); // 404

            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest(); // 400
            var department = _departmentRepositry.Get(id.Value);

            if (department is null) return NotFound(); // 404

            return View(department);
        }

        public IActionResult Edit(Department model)
        {
            if (ModelState.IsValid)
            {
                var Count = _departmentRepositry.Update(model);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest(); // 400
            var department = _departmentRepositry.Get(id.Value);

            if (department is null) return NotFound(); // 404

            return View(department);
        }

        public IActionResult Delete(Department model)
        {
            if (ModelState.IsValid)
            {
                var Count = _departmentRepositry.Delete(model);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }
    }
}
