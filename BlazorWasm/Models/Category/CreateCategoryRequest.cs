using System.ComponentModel.DataAnnotations;

namespace BlazorWasm.Models.Category
{
    public class CreateCategoryRequest
    {
        [Required(ErrorMessage = "Le champ ne peut pas être vide")]
        public string Name { get; set; } = string.Empty;
    }
}
