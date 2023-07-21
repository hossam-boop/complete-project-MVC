using BLL.internalinterface;
using BLL.Reposities;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Assignment02.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        //private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(/*IDepartmentRepository departmentRepository*/ IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_departmentRepository = departmentRepository;
        }
        public async Task <IActionResult> Index()
        {
            //ViewData["Message"] = "Hello From Department Controller! [ViewData]";
            //ViewBag.MessageViewBag = "Hello From Department Controller! [ViewBag]";
            TempData.Keep("Message");
            var departemt = await _unitOfWork.DepartmentRepository.GetALL();
            return View(departemt);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.DepartmentRepository.Add(department);
                TempData["Message"] = "Hello From Department Controller (Create => Index) [TempData]";
                return RedirectToAction("Index");

            }
            return View(department);
        }
        public async Task <IActionResult> Details( int? id)
        {
            if( id is null)
                return  NotFound();
            var department = await _unitOfWork.DepartmentRepository.Get(id.Value);

            if (department is null)
                return NotFound();

            return View(department);

        }
        
        public async Task <IActionResult> Update(int? id)
        {
            if (id is null)
                return NotFound();
            var department = await _unitOfWork.DepartmentRepository.Get(id.Value);

            if (department is null)
                return NotFound();

            return View(department);

        }
        [HttpPost]
        public async Task <IActionResult> Update(int? id,Department department)
        {
            if (id != department.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                
                try
                {
                    await _unitOfWork.DepartmentRepository.Update(department);
                    return RedirectToAction("Index");

                }
                catch (Exception ex )
                {
                    return View(department);

                }
            }
            return View(department);
        }

        public async Task<IActionResult> Delele(int? id)
        {
            if (id is null)
                return NotFound();

            var department = await _unitOfWork.DepartmentRepository.Get(id);

            if (department is null)
                return NotFound();

            await _unitOfWork.DepartmentRepository.Delete(department);
            return RedirectToAction("Index");

            //return View(employee);
        }




        //[HttpPost]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }


        //    var department = await _departmentRepository.Get(id);

        //    if (department == null)
        //    {
        //        return NotFound();

        //    }
        //    await _departmentRepository.Delete(department);
        //    return RedirectToAction("Index");

        //}




    }
}
