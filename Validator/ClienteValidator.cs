using System.Text.RegularExpressions;
using PIM_IV.Interfaces;
using PIM_IV.Models;

namespace PIM_IV.Validator;

public class ClienteValidator : IValidator
{
    public List<Erro>? Erros { get; } = new();

    public bool ValidateModel(object model)
    {
        if (ValidateTelefone(model as Cliente) && ValidateDocumento(model as Cliente))
        {
            return true;
        }

        if (!ValidateDocumento(model as Cliente))
        {
            AddError("Documento", "Documento inválido!");
        }

        if (!ValidateTelefone(model as Cliente))
        {
            AddError("Telefone", "Telefone inválido!");
        }

        return false;
    }

    private void AddError(string nomeCampo, string mensagemErro)
    {
        Erro erro = new()
        {
            NomeCampo = nomeCampo,
            MensagemErro = mensagemErro
        };
        Erros?.Add(erro);
    }

    private static bool ValidateTelefone(Cliente? cliente)
    {
        return cliente is { Telefone: not null } && Regex.IsMatch(cliente.Telefone, @"^\d{11}$");
    }

    private static bool ValidateDocumento(Cliente? cliente)
    {
        if (cliente is { TipoDocumento: "CPF" } && Regex.IsMatch(cliente.Documento, @"^\d{9}$"))
        {
            Console.WriteLine("Documento é um CPF válido!");
            return true;
        }

        if (cliente is { TipoDocumento: "CNPJ" } && Regex.IsMatch(cliente.Documento, @"^\d{14}$"))
        {
            Console.WriteLine("Documento é um CNPJ válido!");
            return true;
        }

        return false;
    }
}