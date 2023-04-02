using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace CursminimalAPI.Data;

public class DatabaseInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(
            @"CREATE TABLE IF NOT EXISTS Books (
                Isbn TEXT PRIMARY_KEY,
                Title TEXT NOT_NULL,
                Author TEXT NOT_NULL,
                ShortDescription TEXT NOT_NULL,
                PageCount INTEGER,
                ReleaseDate TEXT NOT_NULL
            )"
        );
    }
}
