using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.internalinterface
{
    public interface IGenericRepository<T>
        {
        Task<T> Get(int? id);
        Task<IEnumerable <T>> GetALL();

        Task <int> Add(T Obj);
        Task<int> Update(T Obj);
        Task<int> Delete(T Obj);

        }
}
