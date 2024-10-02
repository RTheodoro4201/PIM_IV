using System.Data;
using Dapper;
using PIM_IV.Models;

namespace PIM_IV.Repositories;
public class CompraRepository : IRepository<Compra>
{
    private readonly IDbConnection _dbConnection;

    public CompraRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Compra>> GetAll()
    {
        return await _dbConnection.QueryAsync<Compra>("SELECT * FROM Compras");
    }

    public async Task<Compra?> GetById(int id)
    {
        return await _dbConnection.QueryFirstOrDefaultAsync<Compra>("SELECT * FROM Compras WHERE Id = @Id", new { Id = id });
    }

    public async Task Add(Compra entity)
    {
        var query = "INSERT INTO Compras (IngredienteId, Quantidade, Preco, Data) VALUES (@IngredienteId, @Quantidade, @Preco, @Data)";
        await _dbConnection.ExecuteAsync(query, entity);
    }

    public async Task Update(Compra entity)
    {
        var query = "UPDATE Compras SET IngredienteId = @IngredienteId, Quantidade = @Quantidade, Preco = @Preco, Data = @Data WHERE Id = @Id";
        await _dbConnection.ExecuteAsync(query, entity);
    }

    public async Task Delete(int id)
    {
        await _dbConnection.ExecuteAsync("DELETE FROM Compras WHERE Id = @Id", new { Id = id });
    }
}
