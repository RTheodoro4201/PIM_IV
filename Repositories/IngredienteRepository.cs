using System.Data;
using Dapper;
using PIM_IV.Models;

namespace PIM_IV.Repositories;
public class IngredienteRepository : IIngredienteRepository
{
    private readonly IDbConnection _dbConnection;

    public IngredienteRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Ingrediente>> GetAll()
    {
        return await _dbConnection.QueryAsync<Ingrediente>("SELECT * FROM Ingredientes");
    }

    public async Task<Ingrediente?> GetById(int id)
    {
        return await _dbConnection.QueryFirstOrDefaultAsync<Ingrediente>("SELECT * FROM Ingredientes WHERE Id = @Id", new { Id = id });
    }

    public async Task Add(Ingrediente entity)
    {
        var query = "INSERT INTO Ingredientes (Nome, UnidadeMedida) VALUES (@Nome, @UnidadeMedida)";
        await _dbConnection.ExecuteAsync(query, entity);
    }

    public async Task Update(Ingrediente entity)
    {
        var query = "UPDATE Ingredientes SET Nome = @Nome, UnidadeMedida = @UnidadeMedida WHERE Id = @Id";
        await _dbConnection.ExecuteAsync(query, entity);
    }


    public async Task UpdateQuantidade(Ingrediente entity, decimal quantidade)
    {
        entity.QuantidadeEstoque += quantidade;
        var query = "UPDATE Ingredientes SET QuantidadeEstoque = @QuantidadeEstoque WHERE Id = @Id";
        await _dbConnection.ExecuteAsync(query, entity);
    }

    public async Task Delete(int id)
    {
        await _dbConnection.ExecuteAsync("DELETE FROM Ingredientes WHERE Id = @Id", new { Id = id });
    }
}
