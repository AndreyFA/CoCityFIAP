using System.ComponentModel.DataAnnotations;

namespace CoCity.WebAPI.Models
{
    public class AutenticacaoModel
    {
        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(40)]
        public string Senha { get; set; }
    }
}
