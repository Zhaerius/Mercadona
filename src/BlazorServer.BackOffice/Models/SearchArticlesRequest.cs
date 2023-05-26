using System.ComponentModel.DataAnnotations;

namespace BlazorServer.BackOffice.Models
{
    public class SearchArticlesRequest
    {
        [Required]
        [StringLength(12, MinimumLength = 2)]
        public string? Name { get; set; }
    }
}
