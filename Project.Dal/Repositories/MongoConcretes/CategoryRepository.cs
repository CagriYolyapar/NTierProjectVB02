using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.MongoConcretes
{
    public class CategoryRepository : BaseRepository<Category> , ICategoryRepository
    {
    }
}
