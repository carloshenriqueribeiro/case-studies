using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class ClienteModel
    {
        
        public Int32 ClienteId { get; set; }

        [Required]
        [Display(Name = "Nome Completo:")]
        public String Nome { get; set; }


        [Required]
        [Display(Name = "CPF:")]
        public String CPF { get; set; }


        [Display(Name = "Endereço completo:")]
        public String Endereco { get; set; }


        [Display(Name = "Email:")]
        public String Email { get; set; }
    }
}
