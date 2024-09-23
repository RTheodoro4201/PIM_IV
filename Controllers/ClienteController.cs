using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using PIM_IV.Validator;
using PIM_IV.Models;
using PIM_IV.Repositories;

namespace PIM_IV.Controllers;

public class ClienteController(IRepository<Cliente> clienteRepository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var clientes = await clienteRepository.GetAll();
        return View(clientes);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Cliente cliente)
    {
        ClienteValidator validator = new ClienteValidator();

        if (ModelState.IsValid && validator.ValidateModel(cliente))
        {
            await clienteRepository.Add(cliente);
            return RedirectToAction(nameof(Index));
        }

        if (validator.ValidateTelefone(cliente))
        {

        }

        return View(cliente);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var cliente = await clienteRepository.GetById(id);

        if (!ModelState.IsValid || cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Cliente cliente)
    {
        if (id != cliente.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await clienteRepository.Update(cliente);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        return View(cliente);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await clienteRepository.GetById(id);

        if (!ModelState.IsValid || cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (ModelState.IsValid)
        {
            await clienteRepository.Delete(id);
        }
        return RedirectToAction(nameof(Index));
    }

    protected override bool ValidateCliente(Object model)
    {
        if (ValidarTelefone(model as Cliente) && ValidarDocumento(model as Cliente))
        {
            return true;
        }

        if (!ValidarDocumento(model as Cliente))
        {
            ModelState.AddModelError("Documento", "Documento Inválido!");
        }

        if (!ValidarTelefone(model as Cliente))
        {
            ModelState.AddModelError("Telefone", "Telefone Inválido!");
        }

        return false;
    }

    private static bool ValidarTelefone(Cliente? cliente)
    {
        return cliente.Telefone != null && Regex.IsMatch(cliente.Telefone, @"^\d{11}$");
    }

    private static bool ValidarDocumento(Cliente? cliente)
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