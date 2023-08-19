using System.ComponentModel.DataAnnotations;

namespace BlazorServer.BackOffice.Models.Category
{
    public class UpdateCategoryRequest
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
