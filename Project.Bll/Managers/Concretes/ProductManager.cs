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
    public class ProductManager(IProductRepository repository): BaseManager<Product>(repository),IProductManager
    {
        private readonly IProductRepository _repository = repository;
    }
}
