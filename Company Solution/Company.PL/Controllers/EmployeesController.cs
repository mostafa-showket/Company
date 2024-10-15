using AutoMapper;
using Company.BLL;
using Company.DAL.Models;
using Company.PL.Helper;
using Company.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace Company.PL.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IUnitOfwork _unitOfwork;
        //private readonly IEmployeeRepository _employeeRepository;
        //private readonly IDepartmentRespository _departmentRespository;
        private readonly IMapper _mapper;

        public EmployeesController(
            //IEmployeeRepository employeeRepository,
            //IDepartmentRespository departmentRespository,
            IUnitOfwork unitOfwork,
            IMapper mapper)
        {
            _unitOfwork = unitOfwork;
            //_employeeRepository = employeeRepository;
            //_departmentRespository = departmentRespository;

            _mapper = mapper;
        }

        public IActionResult Index(string searchInput)
        {
            var result = Enumerable.Empty<Employee>();
            var employeesViewModel = new Collection<EmployeeViewModel>();

            if (string.IsNullOrEmpty(searchInput)) result = _unitOfwork.EmployeeRepository.GetAll();
            else result = _unitOfwork.EmployeeRepository.GetByName(searchInput);

            // AutoMapping
            var employees = _mapper.Map<IEnumerable<EmployeeViewModel>>(result);

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
            var departments = _unitOfwork.DepartmentRespository.GetAll(); // Extra Information

            ViewData["Departments"] = departments;

            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image is not null) model.ImageName = DocumentSettings.Upload(model.Image, "images");

                // Casting : EmployeeViewModel --> Employee
                // Manual Mapping 

                //Employee employee = new Employee()
                //{
                //    Name = model.Name,
                //    Address = model.Address,
                //    Age = model.Age,
                //    Salary = model.Salary,
                //    PhoneNumber = model.PhoneNumber,
                //    Email = model.Email,
                //    IsActive = model.IsActive,
                //    IsDeleted = model.IsDeleted,
                //    DateOfCreation = model.DateOfCreation,
                //    HiringDate = model.HiringDate,
                //    WorkFor = model.WorkFor,
                //    WorkForId = model.WorkForId
                //};

                Employee employee = _mapper.Map<Employee>(model);

                _unitOfwork.EmployeeRepository.Add(employee);
                var count = _unitOfwork.Complete();

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

            var employee = _mapper.Map<EmployeeViewModel>(_unitOfwork.EmployeeRepository.Get(id.Value));

            if (employee is null) return NotFound();

            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var departments = _unitOfwork.DepartmentRespository.GetAll();

            ViewData["Departments"] = departments;

            return Details(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel model)
        {
            try
            {
                if (id != model.Id) return BadRequest();

                if (ModelState.IsValid)
                {
                    if (model.ImageName is not null) DocumentSettings.Delete(model.ImageName, "images");
                    if (model.Image is not null) model.ImageName = DocumentSettings.Upload(model.Image, "images");
                    //Employee employee = new Employee()
                    //{
                    //    Name = model.Name,
                    //    Address = model.Address,
                    //    Age = model.Age,
                    //    Salary = model.Salary,
                    //    PhoneNumber = model.PhoneNumber,
                    //    Email = model.Email,
                    //    IsActive = model.IsActive,
                    //    IsDeleted = model.IsDeleted,
                    //    DateOfCreation = model.DateOfCreation,
                    //    HiringDate = model.HiringDate,
                    //    WorkFor = model.WorkFor,
                    //    WorkForId = model.WorkForId
                    //};

                    Employee employee = _mapper.Map<Employee>(model);

                    _unitOfwork.EmployeeRepository.Update(employee);
                    var count = _unitOfwork.Complete();
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
        public IActionResult Delete([FromRoute] int? id, EmployeeViewModel model)
        {
            try
            {
                if (id != model.Id) return BadRequest();

                if (ModelState.IsValid)
                {
                    if (model.ImageName is not null) DocumentSettings.Delete(model.ImageName, "images");

                    Employee employee = _mapper.Map<Employee>(model);

                    _unitOfwork.EmployeeRepository.Delete(employee);
                    var count = _unitOfwork.Complete();
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
