using System.ComponentModel.DataAnnotations;
using gr2_api.Objects;

namespace gr2_api.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres.")]
        [MinLength(2, ErrorMessage = "Nome deve ter pelo menos 2 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        public Email Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.")]
        public Senha Senha { get; set; }
    }
}