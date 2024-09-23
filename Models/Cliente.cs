using System.ComponentModel.DataAnnotations;

namespace PIM_IV.Models;

public enum TipoDocumento
{
    CPF = 1,
    CNPJ = 2
}
public class Cliente
{
    [Display(Name = "Código")]
    public int Id { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "Campo nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
    [RegularExpression(@"^[a-zA-Zà-úÀ-Ú '-]+(?: [a-zA-Zà-úÀ-Ú '-]+)*$", ErrorMessage = "Nome inválido. Use apenas letras, espaços, hífens e apóstrofos.")]
    public string? Nome { get; set; }

    [Display(Name = "Nº do Documento")]
    [Required(ErrorMessage = "Campo documento é obrigatório.")]
    public string? Documento { get; set; }

    [Display(Name = "Tipo de Documento ")]
    [Required(ErrorMessage = "Selecione um tipo de documento.")]
    public TipoDocumento TipoDocumento { get; set; }

    [Display(Name = "Telefone")]
    [Required(ErrorMessage = "Campo telefone é obrigatório.")]
    public string? Telefone { get; set; }
}
