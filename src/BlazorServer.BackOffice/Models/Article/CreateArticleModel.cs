using System.ComponentModel.DataAnnotations;


namespace BlazorServer.BackOffice.Models.Article
{
    public class CreateArticleModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public Guid? CategoryId { get; set; }
        public string? Image { get; set; }
        [Required]
        public double? BasePrice { get; set; }
        public bool Publish { get; set; }
    }
}
