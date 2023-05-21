using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamposDealerWebProject.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "Campo de prenchimento obrigatório!")]
        [StringLength(150, ErrorMessage = "Limite de 150 caracteres atingido!")]
        [Display(Name = "Descrição do produto")]
        public string DscProduto { get; set; }

        [Required(ErrorMessage = "Campo de prenchimento obrigatório!")]
        [Display(Name = "Valor unitário do produto")]
        [Column(TypeName = "decimal(5,2)")]
        public float VlrUnitario { get; set; }

        public List<Venda> Vendas  { get; set; }
    }
}
