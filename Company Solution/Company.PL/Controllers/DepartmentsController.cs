using Company.BLL;
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

        public async Task<IActionResult> Index()
        {
            var departments = await _unitOfwork.DepartmentRespository.GetAllAsync();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department model)
        {
            if (ModelState.IsValid)
            {
                await _unitOfwork.DepartmentRespository.AddAsync(model);
                var count = await _unitOfwork.CompleteAsync();

                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int? id, string viewName = "Details")
        {
            if (id is null) return BadRequest(); // 400
            var department = await _unitOfwork.DepartmentRespository.GetAsync(id.Value);

            if (department is null) return NotFound(); // 404

            return View(viewName, department);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id is null) return BadRequest(); // 400
            //var department = _departmentRepositry.Get(id.Value);

            //if (department is null) return NotFound(); // 404

            //return View(department);
            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int? id, Department model)
        {
            try
            {
                if (id != model.Id) return BadRequest();

                if (ModelState.IsValid)
                {
                    _unitOfwork.DepartmentRespository.Update(model);
                    var count = await _unitOfwork.CompleteAsync();

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
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id is null) return BadRequest(); // 400
            //var department = _departmentRepositry.Get(id.Value);

            //if (department is null) return NotFound(); // 404

            //return View(department);
            return await Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int? id, Department model)
        {
            try
            {
                if (id != model.Id) return BadRequest();

                if (ModelState.IsValid)
                {
                    _unitOfwork.DepartmentRespository.Delete(model);
                    var count = await _unitOfwork.CompleteAsync();
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
