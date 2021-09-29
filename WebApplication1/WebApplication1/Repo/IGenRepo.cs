using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repo
{
  public  interface IGenRepo <T> where T :class, IModelBase
    {
        Task <T> Get(int id);
        //IEnumerable<T> Get();
        Task<IEnumerable<T>> Get();
        ///void Add(T obj);
        Task Add(T obj);
        Task update(T obj);
        public Task<IEnumerable<T>> GetPage(int size, int index);
    }


    public class GenRepo<T>:IGenRepo <T> where T : class , IModelBase
    {
        public readonly AppDBContext _dbContext;
        public GenRepo(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        //public void Add(T obj)
        public async Task Add(T obj)
        {
            // _dbContext.Set<T>().Add(obj);
            await _dbContext.Set<T>().AddAsync(obj);
            // _dbContext.SaveChanges();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            //  return _dbcontext.Set<T>().FirstOrDefault(x => x.id == id);
               
             
           var response = await _dbContext.Set<T>().FirstOrDefaultAsync(i => i.id == id);
            return response;




        }

        public async Task<IEnumerable<T>> Get()
        {
            //return _dbContext
            //await _dbContext.Set<T>().ToList();
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetPage(int size, int index)
        {
            return  _dbContext.Set<T>().Take(size).ToList().Skip(size * (index - 1));
        }
        public async Task update(T obj)
        {
            ///
        }
    }
}
