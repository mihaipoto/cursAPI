using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace CursminimalAPI.Data;

public class SqliteConnectionFactory : IDbConnectionFactory
{

    private readonly string _connectionstring;

    public SqliteConnectionFactory(string connectionstring)
    {
        _connectionstring = connectionstring;
    }

    public async Task<IDbConnection> CreateConnectionAsync()
    {

        var connection = new SqliteConnection(_connectionstring);
        await connection.OpenAsync();
        return connection;
    }
}
