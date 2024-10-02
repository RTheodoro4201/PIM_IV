using Microsoft.AspNetCore.Mvc;
using PIM_IV.Models;
using PIM_IV.Repositories;

public class CompraController : Controller
{
    private readonly IRepository<Compra> _compraRepository;
    /*
    private readonly IIngredienteRepository _ingredienteRepository;

    public CompraController(
        IRepository<Compra> compraRepository,
        IIngredienteRepository ingredienteRepository
    )
    {

        _compraRepository = compraRepository;
        _ingredienteRepository = ingredienteRepository;
    }

    public async Task<IActionResult> Index()
    {
        var compras = await _compraRepository.GetAll();
        foreach (var compra in compras)
        {
            var ingrediente = await _ingredienteRepository.GetById(compra.IngredienteId);
            if (ingrediente == null)
            {
                return NotFound();
            }
            compra.IngredienteNome = ingrediente.Nome;
        }
        return View(compras);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Compra compra)
    {
        if (ModelState.IsValid)
        {
            var ingrediente = await _ingredienteRepository.GetById(compra.IngredienteId);
            if (ingrediente == null)
            {
                return NotFound();
            }

            await _compraRepository.Add(compra);
            await _ingredienteRepository.UpdateQuantidade(ingrediente, compra.Quantidade);
            return RedirectToAction(nameof(Index));
        }
        return View(compra);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var compra = await _compraRepository.GetById(id);
        if (compra == null)
        {
            return NotFound();
        }
        return View(compra);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Compra compra)
    {
        if (id != compra.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _compraRepository.Update(compra);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        return View(compra);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var compra = await _compraRepository.GetById(id);
        if (compra == null)
        {
            return NotFound();
        }

        var ingrediente = await _ingredienteRepository.GetById(compra.IngredienteId);
        if (ingrediente == null)
        {
            return NotFound();
        }
        compra.IngredienteNome = ingrediente.Nome;

        return View(compra);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _compraRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    */
}
