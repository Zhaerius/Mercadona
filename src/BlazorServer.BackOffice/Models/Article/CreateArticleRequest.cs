using System.ComponentModel.DataAnnotations;


namespace BlazorServer.BackOffice.Models.Article
{
    public class CreateArticleRequest
    {
        [Required(ErrorMessage = "Le champ ne doit pas être vide")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Le champ ne doit pas être vide")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Le champ ne doit pas être vide")]
        public Guid? CategoryId { get; set; }
        public string? Image { get; set; }
        [Required(ErrorMessage = "Le champ ne doit pas être vide")]
        public double? BasePrice { get; set; }
        public bool Publish { get; set; } = true;
    }
}
