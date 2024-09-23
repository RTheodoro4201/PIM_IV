using System.Text.RegularExpressions;
using PIM_IV.Abstract;
using PIM_IV.Models;
using

namespace PIM_IV.Validator;

public class ClienteValidator : IValidator
{
    public bool ValidateModel(object model)
    {
        if (ValidateTelefone(model as Cliente) && ValidateDocumento(model as Cliente))
        {
            return true;
        }

        if (!ValidateDocumento(model as Cliente))
        {
            ModelState.AddModelError("Documento", "Documento Inválido!");
        }

        if (!ValidateTelefone(model as Cliente))
        {
            ModelState.AddModelError("Telefone", "Telefone Inválido!");
        }

        return false;
    }

    private static bool ValidateTelefone(Cliente? cliente)
    {
        return cliente.Telefone != null && Regex.IsMatch(cliente.Telefone, @"^\d{11}$");
    }

    private static bool ValidateDocumento(Cliente? cliente)
    {
        if (cliente is { TipoDocumento: TipoDocumento.CPF, Documento: not null } && Regex.IsMatch(cliente.Documento, @"^\d{9}$"))
        {
            Console.WriteLine("Documento é um CPF válido!");
            return true;
        }

        if (cliente is { TipoDocumento: TipoDocumento.CNPJ, Documento: not null } && Regex.IsMatch(cliente.Documento, @"^\d{14}$"))
        {
            Console.WriteLine("Documento é um CNPJ válido!");
            return true;
        }

        return false;
    }
}