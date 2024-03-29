﻿using System.ComponentModel.DataAnnotations;

namespace BlazorWasm.Models.Auth
{
    public record LoginRequest
    {
        [Required(ErrorMessage = "L'adresse mail est requise")]
        [EmailAddress(ErrorMessage = "Adresse mail invalide")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Le mot de passe est requis")]
        public string? Password { get; set; }
    }
}
