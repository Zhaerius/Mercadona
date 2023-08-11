using System.ComponentModel.DataAnnotations;

namespace BlazorServer.BackOffice.Models
{
    public class CreateCategoryRequest
    {
        [Required(ErrorMessage = "Le champ ne peut pas être vide")]
        public string? Name { get; set; }
    }
}
