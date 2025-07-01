using System.ComponentModel.DataAnnotations;

namespace gr2_api.Models
{
    public class Componente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public ICollection<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();
    }
}