using System.ComponentModel.DataAnnotations;

namespace BlazorWasm.BackOffice.Models
{
    public class SearchArticlesRequest
    {
        [Required]
        [StringLength(12, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
    }
}
