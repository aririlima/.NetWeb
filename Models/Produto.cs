using System;
using System.ComponentModel.DataAnnotations;


namespace Arianna_Lima_av1.Models
{
    public class Produto
    {

        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Required(ErrorMessage = "O campo marca é obrigatório.")]
        [Display(Name = "Marca")]
        public string marca { get; set; }
        [Required(ErrorMessage = "Por favor, digite aquantidade em estoque")]
        [Display(Name = "Quantidade em estoque")]
        public int estoque { get; set; }
    }

}
