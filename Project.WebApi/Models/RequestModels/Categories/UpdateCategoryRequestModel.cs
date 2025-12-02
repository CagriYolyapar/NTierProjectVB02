using System.ComponentModel.DataAnnotations;

namespace Project.WebApi.Models.RequestModels.Categories
{
    public class UpdateCategoryRequestModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

    }
}
