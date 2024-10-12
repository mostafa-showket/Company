using Company.BLL;
using Company.BLL.Interfaces;
using Company.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.PL.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IUnitOfwork _unitOfwork;

        public DepartmentsController(IUnitOfwork unitOfwork) // Ask CLR to Create object from DepartmentRepositry
        {
            _unitOfwork = unitOfwork;
        }

        public IActionResult Index()
        {
            var departments = _unitOfwork.DepartmentRespository.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department model)
        {
            if (ModelState.IsValid)
            {
                _unitOfwork.DepartmentRespository.Add(model);
                var count = _unitOfwork.Complete(); 
                
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id is null) return BadRequest(); // 400
            var department = _unitOfwork.DepartmentRespository.Get(id.Value);

            if (department is null) return NotFound(); // 404

            return View(viewName, department);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //if (id is null) return BadRequest(); // 400
            //var department = _departmentRepositry.Get(id.Value);

            //if (department is null) return NotFound(); // 404

            //return View(department);
            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int? id, Department model)
        {
            try
            {
                if (id != model.Id) return BadRequest();

                if (ModelState.IsValid)
                {
                    _unitOfwork.DepartmentRespository.Update(model);
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
            //if (id is null) return BadRequest(); // 400
            //var department = _departmentRepositry.Get(id.Value);

            //if (department is null) return NotFound(); // 404

            //return View(department);
            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int? id, Department model)
        {
            try
            {
                if (id != model.Id) return BadRequest();

                if (ModelState.IsValid)
                {
                    _unitOfwork.DepartmentRespository.Delete(model);
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
