using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamposDealerWebProject.Models
{
    [Table("Clientes")]
    public class Cliente
    {       
        [Key]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Campo de prenchimento obrigatório!")]
        [StringLength(200, ErrorMessage = "Limite de 200 caracteres atingido!")]
        public string NmCliente { get; set; }

        [Required(ErrorMessage = "Campo de prenchimento obrigatório!")]
        [StringLength(200, ErrorMessage = "Limite de 200 caracteres atingido!")]
        public string Cidade { get; set; }

        public virtual List<Venda> Vendas { get; set; }
        
    }
}
