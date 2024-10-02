using System.ComponentModel.DataAnnotations;

namespace PIM_IV.Models;

public class Funcionario
{
    [Display(Name = "Código")]
    public int Id { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "Campo nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
    [RegularExpression(@"^[a-zA-Zà-úÀ-Ú '-]+(?: [a-zA-Zà-úÀ-Ú '-]+)*$", ErrorMessage = "Nome inválido. Use apenas letras, espaços, hífens e apóstrofos.")]
    public string Nome { get; set; }

    [Display(Name = "Cargo")]
    [Required(ErrorMessage = "Campo cargo é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
    [RegularExpression(@"^[a-zA-Zà-úÀ-Ú '-]+(?: [a-zA-Zà-úÀ-Ú '-]+)*$", ErrorMessage = "Nome inválido. Use apenas letras, espaços, hífens e apóstrofos.")]
    public string Cargo { get; set; }
}