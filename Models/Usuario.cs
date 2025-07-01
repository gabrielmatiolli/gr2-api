using gr2_api.Objects;

namespace gr2_api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Senha Senha { get; set; }
    }
}