using BLL.internalinterface;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Reposities
{
    public class EmpolyeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly MVCAppDbContext _context;

        public EmpolyeeRepository(MVCAppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<string> GetDepartmentByEmployeeId(int? id)
        { 
            var employee = await _context.Employees.Where(e => e.Id == id).Include(e => e.Department).FirstOrDefaultAsync();
            var department = employee.Department;

            return department.Name;
           
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentName(string DeptName)
           => await _context.Employees.Where(e => e.Department.Name == DeptName).ToListAsync();

        public async Task<IEnumerable<Employee>> Search(string name)
             => await _context.Employees.Where(e => e.Name.Contains(name)).ToListAsync();


        //    public int Add(Employee employee)
        //    {
        //        _context.Employees.Add(employee);
        //        return _context.SaveChanges();

        //    }

        //    public int Delete(Employee employee)
        //    {
        //        _context.Employees.Remove(employee);
        //        return _context.SaveChanges();
        //    }

        //    public IEnumerable<Employee> GetALL()
        //    {
        //        return _context.Employees.ToList();

        //    }

        //    public Employee Get(int? id)
        //    {
        //        return _context.Employees.FirstOrDefault(x => x.Id == id);


        //    }

        //    public int Update(Employee employee)
        //    {
        //        _context.Employees.Update(employee);
        //        return _context.SaveChanges();
        //    }
    }
}

