
using System.ComponentModel.DataAnnotations;


namespace Agencia1.Models
{
    public class NovoUser
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Email { get; set; }


        //FK edição

        [Required]
        public int DestinoUserId_Destino { get; set;}
         public DestinoUser DestinoUser { get; set; }






    }

}

    
