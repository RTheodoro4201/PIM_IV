using System.Data;
using Dapper;
using PIM_IV.Models;

namespace PIM_IV.Repositories;
public class ClienteRepository : IRepository<Cliente>
{
    private readonly IDbConnection _dbConnection;

    public ClienteRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Cliente>> GetAll()
    {
        return await _dbConnection.QueryAsync<Cliente>("SELECT * FROM clientes");
    }

    public async Task<Cliente?> GetById(int id)
    {
        return await _dbConnection.QueryFirstOrDefaultAsync<Cliente>("SELECT * FROM clientes WHERE id = @Id", new { Id = id });
    }

    public async Task Add(Cliente entity)
    {
        var query = "INSERT INTO clientes (nome, documento, tipo_documento, telefone) VALUES (@Nome, @Documento, @TipoDocumento, @Telefone)";
        await _dbConnection.ExecuteAsync(query, entity);
    }

    public async Task Update(Cliente entity)
    {
        var query = "UPDATE clientes SET nome = @Nome, documento = @Documento, tipo_documento = @TipoDocumento, telefone = @Telefone WHERE id = @Id";
        await _dbConnection.ExecuteAsync(query, entity);
    }

    public async Task Delete(int id)
    {
        await _dbConnection.ExecuteAsync("DELETE FROM clientes WHERE Id = @Id", new { Id = id });
    }
}