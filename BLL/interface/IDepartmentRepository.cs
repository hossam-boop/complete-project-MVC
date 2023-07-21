using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.internalinterface
   {
    public interface IDepartmentRepository : IGenericRepository<Department>
      {
        //Department Get(int? id);
        //IEnumerable<Department> GetALL();

        //int Add (Department department);
        //int Update (Department department);
        //int Delete (Department department);

        
      }
   }
