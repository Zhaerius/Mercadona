using System.ComponentModel.DataAnnotations;

namespace BlazorServer.BackOffice.Models.Promotion
{
    public class CreatePromotionRequest
    {
        [Required(ErrorMessage = "Le champ ne peut pas être vide")]
        public string Name { get; set; } = string.Empty;

        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }

        [Required(ErrorMessage = "Le champ ne peut pas être vide")]
        public double? Discount { get; set; }
    }
}
