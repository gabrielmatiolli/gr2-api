using System.ComponentModel.DataAnnotations;

namespace gr2_api.Models
{
    public class Equipamento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
    }
}