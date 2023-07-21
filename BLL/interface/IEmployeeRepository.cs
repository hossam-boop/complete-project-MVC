using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.internalinterface
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
       {
        //Employee Get(int? id);
        //IEnumerable<Employee> GetALL();

        //int Add(Employee employee);
        //int Update(Employee employee);
        //int Delete(Employee employee);

        Task<IEnumerable<Employee>> GetEmployeesByDepartmentName(string DeptName);
        Task<string> GetDepartmentByEmployeeId(int? id);

        Task<IEnumerable<Employee>> Search(string name);

    }
}
