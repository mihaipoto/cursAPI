using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursminimalAPI.Models;

namespace CursminimalAPI.Services;

public interface IBookService
{
    Task<bool> CreateAsync(Book book);
    Task<Book?> GetByIsbnAsync(string isbn);
    Task<IEnumerable<Book>> GetAllASync();

    Task<IEnumerable<Book>> SearchByTitleASync(string searchTerm);

    Task<bool> UpdateAsync(Book book);

    Task<bool> DeleteASync(string isbn);
}
