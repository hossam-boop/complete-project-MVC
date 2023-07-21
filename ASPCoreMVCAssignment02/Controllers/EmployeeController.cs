using Assignment02.Helper;
using Assignment02.Models;
using AutoMapper;
using BLL.internalinterface;
using BLL.Reposities;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment02.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //private readonly IEmployeeRepository _employeeRepository ;
        //private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(/*IEmployeeRepository employeeRepository */
            //, IDepartmentRepository departmentRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            //_employeeRepository = employeeRepository ;
            //_departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string SearchValue = "")
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(SearchValue))
            {
                employees = await _unitOfWork.EmployeeRepository.GetALL();

            }
            else
            {
                employees = await _unitOfWork.EmployeeRepository.Search(SearchValue);
            }

            var mappedEmployees = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            return View(mappedEmployees);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = await _unitOfWork.DepartmentRepository.GetALL();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {

                employeeViewModel.ImageUrl = DocumentSettings.UploadFile(employeeViewModel.Image, "Files/Imgs");
                var mappedEmployee = _mapper.Map<Employee>(employeeViewModel);

                await _unitOfWork.EmployeeRepository.Add(mappedEmployee );
                return RedirectToAction("Index");

            }
            return View(employeeViewModel);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return NotFound();
            var employee = await _unitOfWork.EmployeeRepository.Get(id.Value);

            var mappedEmployee = _mapper.Map<EmployeeViewModel>(employee);

            var departmentName  = await _unitOfWork.EmployeeRepository.GetDepartmentByEmployeeId(id);

            employee.Department.Name = departmentName;

            if (employee is null)
                return NotFound();

            return View(mappedEmployee);

        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null)
                return NotFound();
            var employee = await _unitOfWork.EmployeeRepository.Get(id.Value);


            var mappedEmployee = _mapper.Map<EmployeeViewModel>(employee);


            if (employee is null)
                return NotFound();

            return View(mappedEmployee);

        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, EmployeeViewModel employeeViewModel)
        {
            if (id != employeeViewModel.Id)
                return NotFound();
            if (ModelState.IsValid)
            {

                try
                {
                    employeeViewModel.ImageUrl = DocumentSettings.UploadFile(employeeViewModel.Image, "Files/Imgs");

                    var mappedEmployee = _mapper.Map<Employee>(employeeViewModel);
                    await _unitOfWork.EmployeeRepository.Update(mappedEmployee);
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    return View(employeeViewModel);

                }
            }
            return View(employeeViewModel);
        }
        
        public async Task<IActionResult> Delele(int? id)
        {
            if (id is null)
                return NotFound();

            var employee = await _unitOfWork.EmployeeRepository.Get(id);

            if (employee is null)
                return NotFound();

            DocumentSettings.DeleteFile("Imgs", employee.ImageUrl);

            await _unitOfWork.EmployeeRepository.Delete(employee);
            return RedirectToAction("Index");

            //return View(employee);
        }
    }
}
