using PIM_IV.Models;

namespace PIM_IV.Repositories;

public interface IIngredienteRepository : IRepository<Ingrediente>
{
    Task UpdateQuantidade(Ingrediente entity, decimal quantidade);
}