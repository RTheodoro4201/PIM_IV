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
    public string NomeCompleto { get; set; }

    [Display(Name = "Função")]
    [Required(ErrorMessage = "Campo função é obrigatório.")]
    [StringLength(100, ErrorMessage = "A função deve ter no máximo 100 caracteres")]
    [RegularExpression(@"^[a-zA-Zà-úÀ-Ú '-]+(?: [a-zA-Zà-úÀ-Ú '-]+)*$", ErrorMessage = "Função inválida. Use apenas letras, espaços, hífens e apóstrofos.")]
    public string Funcao { get; set; }

    [Display(Name = "Endereço")]
    [Required(ErrorMessage = "Campo endereço é obrigatório.")]
    [StringLength(100, ErrorMessage = "O endereço deve ter no máximo 100 caracteres")]
    [RegularExpression(@"^[a-zA-Zà-úÀ-Ú '-]+(?: [a-zA-Zà-úÀ-Ú '-]+)*$", ErrorMessage = "Endereço inválido. Use apenas letras, espaços, hífens e apóstrofos.")]
    public string Endereco { get; set; }

    [Display(Name = "CPF")]
    [Required(ErrorMessage = "Campo CPF é obrigatório.")]
    public string Cpf { get; set; }

    [Display(Name = "RG")]
    [Required(ErrorMessage = "Campo RG é obrigatório.")]
    public string Rg { get; set; }

    [Display(Name = "Telefone")]
    [Required(ErrorMessage = "Campo telefone é obrigatório")]
    public string Telefone { get; set; }

    [Display(Name = "Salário")]
    [Required(ErrorMessage = "Campo salário é obrigatório")]
    public string Salario { get; set; }

    [Display(Name = "Agência Bancária")]
    [Required(ErrorMessage = "Campo agência bancária é obrigatório")]
    public string AgenciaBancaria { get; set; }

    [Display(Name = "Conta Bancária")]
    [Required(ErrorMessage = "Campo conta bancária é obrigatório")]
    public string ContaBancaria { get; set; }

    [Display(Name = "Data de Nascimento")]
    [Required(ErrorMessage = "Selecione uma data de nascimento")]
    public DateTime DataNascimento { get; set; }
}