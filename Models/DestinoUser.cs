using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agencia1.Models
{
    public class DestinoUser
    {
        [Key]
        [Required]
        public int Id_Destino { get; set; }
        [Required]
        public string País { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string DataSaida { get; set; }   
        [Required]
        public string DataChegada { get; set; } 

        public ICollection<NovoUser> NovoUsers { get; set; }
    }
}
