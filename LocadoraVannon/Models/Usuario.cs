using System.ComponentModel.DataAnnotations;

namespace LocadoraVannon.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Senha { get; set; }
        public DateTime ?DataCadastro { get; set; }
    }
}
