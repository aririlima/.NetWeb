using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Arianna_Lima_av1.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [Display(Name = "Razão social")]
        public string RazaoSocial { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }




    }
}