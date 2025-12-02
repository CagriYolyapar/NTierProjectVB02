using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    //DTO : DTO refactoring
    public interface IManager<T> where T:BaseEntity
    {
        //BL for Queries
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        List<T> GetActives();
        List<T> GetPassives();
        List<T> GetUpdateds();

        //BL for Commands
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<string> SoftDeleteAsync(int id);
        Task<string> HardDeleteAsync(int id);
    }
}
