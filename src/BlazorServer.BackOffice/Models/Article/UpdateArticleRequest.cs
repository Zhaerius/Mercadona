﻿using System.ComponentModel.DataAnnotations;


namespace BlazorServer.BackOffice.Models.Article
{
    public class UpdateArticleRequest
    {
        public Guid Id { get; set; }

        
        [Required(ErrorMessage = "Le champ ne doit pas être vide")]
        public string Name { get; set; } = string.Empty;


        [Required(ErrorMessage = "Le champ ne doit pas être vide")]
        public string Description { get; set; } = string.Empty;


        [Required(ErrorMessage = "Le champ ne doit pas être vide")]
        public Guid CategoryId { get; set; }


        public string? Image { get; set; }


        [Required(ErrorMessage = "Le champ ne doit pas être vide")]
        public double? BasePrice { get; set; }


        public bool Publish { get; set; } = true;
    }
}
