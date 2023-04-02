using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursminimalAPI.Data;
using CursminimalAPI.Models;
using Dapper;

namespace CursminimalAPI.Services;

public class BookService : IBookService
{
    private readonly IDbConnectionFactory _connectionFactory;

    public BookService(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(Book book)
    {
        // var exitstingBook = await GetByIsbnAsync(book.Isbn);
        // if (exitstingBook is not null)
        // {
        //     return false;
        // }
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO Books (Isbn, Title, Author, ShortDescription, PAgeCOunt, ReleaseDate)
            VALUES (@Isbn, @Title, @Author, @ShortDescription, @PageCount, @ReleaseDate)",
            book
        );
        return result > 0;
    }

    public Task<bool> DeleteASync(string isbn)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> GetAllASync()
    {
        throw new NotImplementedException();
    }

    public Task<Book?> GetByIsbnAsync(string isbn)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> SearchByTitleASync(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Book book)
    {
        throw new NotImplementedException();
    }
}
