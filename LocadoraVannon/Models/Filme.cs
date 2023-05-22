using System.ComponentModel.DataAnnotations;

namespace LocadoraVannon.Models
{
    public class Filme
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatório.")]
        public string Diretor { get; set; }
        [Required(ErrorMessage = "O campo Ano é obrigatório.")]
        public string Ano { get; set; }
        [Required(ErrorMessage = "O campo Genero é obrigatório.")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "O campo Sinopse é obrigatório.")]
        public string Sinopse { get; set; }
        public DateTime ?DataCadastro { get; set; }
    }
}
