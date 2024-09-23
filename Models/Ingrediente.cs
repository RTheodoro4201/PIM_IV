using System.ComponentModel.DataAnnotations;

namespace PIM_IV.Models;
public class Ingrediente
{
    [Display(Name = "Código")]
    public int Id { get; set; }

    [Display(Name = "Nome")]
    public string? Nome { get; set; }

    [Display(Name = "Unidade de medida")]
    public string? UnidadeMedida { get; set; }

    [Display(Name = "Quantidade em estoque")]
    public decimal QuantidadeEstoque { get; set; }
}
