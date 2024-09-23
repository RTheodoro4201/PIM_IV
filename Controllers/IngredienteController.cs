using Microsoft.AspNetCore.Mvc;
using PIM_IV.Models;
using PIM_IV.Repositories;

public class IngredienteController : Controller
{
    private readonly IIngredienteRepository _ingredienteRepository;

    public IngredienteController(IIngredienteRepository ingredienteRepository)
    {
        _ingredienteRepository = ingredienteRepository;
    }

    public async Task<IActionResult> Index()
    {
        var ingredientes = await _ingredienteRepository.GetAll();
        return View(ingredientes);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Ingrediente ingrediente)
    {
        if (ModelState.IsValid)
        {
            await _ingredienteRepository.Add(ingrediente);
            return RedirectToAction(nameof(Index));
        }
        return View(ingrediente);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var ingrediente = await _ingredienteRepository.GetById(id);
        if (ingrediente == null)
        {
            return NotFound();
        }
        return View(ingrediente);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Ingrediente ingrediente)
    {
        if (id != ingrediente.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _ingredienteRepository.Update(ingrediente);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        return View(ingrediente);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var ingrediente = await _ingredienteRepository.GetById(id);
        if (ingrediente == null)
        {
            return NotFound();
        }
        return View(ingrediente);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _ingredienteRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
