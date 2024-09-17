using Company.BLL.Interfaces;
using Company.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.PL.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRespository _departmentRespository;

        public EmployeesController(IEmployeeRepository employeeRepository, IDepartmentRespository departmentRespository)
        {
            _employeeRepository = employeeRepository;
            _departmentRespository = departmentRespository;
        }

        public IActionResult Index(string searchInput)
        {
            var employees = Enumerable.Empty<Employee>();
            if (string.IsNullOrEmpty(searchInput)) employees = _employeeRepository.GetAll();
            else employees = _employeeRepository.GetByName(searchInput);

            //string Message = "Hello World";

            // Key ----- Value
            // Message : 

            // View's Dictionary : transfer data from action to view [One Way]

            // 1. ViewData : Property Inhertied From Controller -- Dictionary

            //ViewData["Message"] = Message + " From ViewData";

            // 2. ViewBag  : Property Inhertied From Controller -- Dynmic

            //ViewBag.Message = Message + " From ViewBag";

            // 3. TempData : Property Inhertied From Controller -- Dictionary
            // Transfer The Data from request to another

            //TempData["Message01"] = Message + " From TempData";

            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = _departmentRespository.GetAll(); // Extra Information

            ViewData["Departments"] = departments;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var count = _employeeRepository.Add(model);
                if (count > 0)
                {
                    TempData["Message"] = "Employee is created successfully";
                }
                else
                {
                    TempData["Message"] = "Employee didn't created successfully";
                }
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id is null) return BadRequest();

            var employee = _employeeRepository.Get(id.Value);

            if (employee is null) return NotFound();

            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var departments = _departmentRespository.GetAll();

            ViewData["Departments"] = departments;

            return Details(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, Employee model)
        {
            try
            {
                if (id != model.Id) return BadRequest();

                if (ModelState.IsValid)
                {
                    var count = _employeeRepository.Update(model);
                    if (count > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int? id, Employee model)
        {
            try
            {
                if (id != model.Id) return BadRequest();

                if (ModelState.IsValid)
                {
                    var count = _employeeRepository.Delete(model);
                    if (count > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }
    }
}
