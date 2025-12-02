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
    public class CategoryManager(ICategoryRepository repository):BaseManager<Category>(repository),ICategoryManager
    {
        private readonly ICategoryRepository _repository = repository;
    }
}
