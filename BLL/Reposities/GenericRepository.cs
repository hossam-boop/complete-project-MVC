using BLL.internalinterface;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Reposities
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MVCAppDbContext _context;

        public GenericRepository(MVCAppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(T Obj)
        {
            await _context.Set<T>().AddAsync(Obj);
            return await _context.SaveChangesAsync();   
        }

        public async Task<int> Delete(T Obj)
        {
            _context.Set<T>().Remove(Obj);
            return await _context.SaveChangesAsync();  
        }

        public async Task<T> Get(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetALL()
        {
            return await _context.Set<T>().ToListAsync();   
           
        }

        public async  Task<int> Update(T Obj)
        {
            _context.Set<T>().Update(Obj);
            return await _context.SaveChangesAsync();

        }

        
    }
}
