using System.ComponentModel.DataAnnotations;

namespace BlazorServer.BackOffice.Models.Article
{
    public class SearchArticlesRequest
    {
        [Required]
        [StringLength(12, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
    }
}
