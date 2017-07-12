using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroContatosEntityFrameworkRefat.Entities
{
    public class Contato
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Digite o e-mail")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; }
    }
}