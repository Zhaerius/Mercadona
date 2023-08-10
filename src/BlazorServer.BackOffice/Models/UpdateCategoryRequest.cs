using System.ComponentModel.DataAnnotations;

namespace BlazorServer.BackOffice.Models
{
    public class UpdateCategoryRequest
    {

        public Guid Id { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
