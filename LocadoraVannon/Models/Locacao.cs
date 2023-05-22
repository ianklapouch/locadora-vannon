using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVannon.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        [NotMapped]
        public Cliente? Cliente { get; set; }
        public int FilmeId { get; set; }
        [NotMapped]
        public Filme? Filme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public decimal ValorPago { get; set; }
    }
}

