using System.Data;
using Dapper;
using PIM_IV.Models;

namespace PIM_IV.Repositories;
public class FuncionarioRepository : IRepository<Funcionario>
{
    private readonly IDbConnection _dbConnection;

    public FuncionarioRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Funcionario>> GetAll()
    {
        return await _dbConnection.QueryAsync<Funcionario>("SELECT * FROM funcionarios");
    }

    public async Task<Funcionario?> GetById(int id)
    {
        return await _dbConnection.QueryFirstOrDefaultAsync<Funcionario>("SELECT * FROM funcionarios WHERE id = @Id", new { Id = id });
    }

    public async Task Add(Funcionario entity)
    {
        var query = "INSERT INTO funcionarios (nome, cargo) VALUES (@Nome, @Cargo)";
        await _dbConnection.ExecuteAsync(query, entity);
    }

    public async Task Update(Funcionario entity)
    {
        var query = "UPDATE funcionarios SET nome = @Nome, cargo = @Cargo WHERE id = @Id";
        await _dbConnection.ExecuteAsync(query, entity);
    }

    public async Task Delete(int id)
    {
        await _dbConnection.ExecuteAsync("DELETE FROM funcionarios WHERE Id = @Id", new { Id = id });
    }
}