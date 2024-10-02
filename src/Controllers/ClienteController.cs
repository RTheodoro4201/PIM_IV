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

        if (validator.Erros.Any())
        {
            foreach (var erro in validator.Erros)
            {
                ModelState.AddModelError(erro.NomeCampo, erro.MensagemErro);
            }
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
}