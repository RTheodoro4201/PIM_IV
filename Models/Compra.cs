using System.ComponentModel.DataAnnotations;

namespace PIM_IV.Models
{
    public class Compra
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Id do ingrediente")]
        public int IngredienteId { get; set; }

        [Display(Name = "Nome do ingrediente")]
        public string? IngredienteNome { get; set; }

        [Display(Name = "Quantidade")]
        public decimal Quantidade { get; set; }

        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Data da compra")]
        public DateTime Data { get; set; }
    }
}