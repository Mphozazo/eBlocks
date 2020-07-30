using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using eBlocks.Assessment.Models.Interface;

namespace eBlocks.Core.Interfaces 
{
    public interface IRepository<T> where T:class , IEntity
    {
        Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll(); 
       
        Task<bool> Add(T entity);
        Task<bool> Delete(string id);

        Task<bool> Delete(T entity);
        Task<bool> Update(T entity);
        Task<T> FindByName(string name);      

        Task<T> FindById(string id);      
    }
}
