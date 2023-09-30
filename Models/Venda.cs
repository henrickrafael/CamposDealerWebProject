using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamposDealerWebProject.Models
{
    [Table("Vendas")]
    public class Venda
    {
        [Key]
        public int IdVenda { get; set; }

        [Required(ErrorMessage = "Campo de prenchimento obrigatório!")]
        [Display(Name = "Quantidade do produto")]        
        public int QtdVenda { get; set; }                

        [Required(ErrorMessage = "Campo de prenchimento obrigatório!")]
        public DateTime DthVenda { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public float VlrTotalVenda { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
