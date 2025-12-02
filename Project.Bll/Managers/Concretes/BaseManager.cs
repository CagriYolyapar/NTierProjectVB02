using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    public abstract class BaseManager<T> : IManager<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        protected BaseManager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.Status = Entities.Enums.DataStatus.Inserted;
            await _repository.CreateAsync(entity);
        }

        public List<T> GetActives()
        {
            return _repository.Where(x => x.Status != Entities.Enums.DataStatus.Deleted).ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public  List<T> GetPassives()
        {
            return _repository.Where(x => x.Status == Entities.Enums.DataStatus.Deleted).ToList();
        }

        public List<T> GetUpdateds()
        {
            return _repository.Where(x => x.Status == Entities.Enums.DataStatus.Updated).ToList();

        }

        public async Task<string> HardDeleteAsync(int id)
        {
            T originalValue = await _repository.GetByIdAsync(id);
            if (originalValue == null || originalValue.Status != Entities.Enums.DataStatus.Deleted)
                 return "Sadece bulunabilen ve pasif veriler silinebilir";
            await _repository.DeleteAsync(originalValue);
            return $"{id} id'li veri silinmiştir";
            
        }

        public async Task<string> SoftDeleteAsync(int id)
        {
            T originalValue = await _repository.GetByIdAsync(id);
            if (originalValue == null || originalValue.Status == Entities.Enums.DataStatus.Deleted)
                return "Veri ya zaten pasif ya da bulunamadı";
            originalValue.Status = Entities.Enums.DataStatus.Deleted;
            originalValue.DeletedDate = DateTime.Now;
            await _repository.SaveChangesAsync();
            return $"{id} id'li veri pasife cekilmiştir";
            

            
        }

        public async Task UpdateAsync(T entity)
        {
            T originalValue = await _repository.GetByIdAsync(entity.Id);
            entity.UpdatedDate = DateTime.Now;
            entity.Status = Entities.Enums.DataStatus.Updated;
            await _repository.UpdateAsync(originalValue, entity);
        }
    }
}
