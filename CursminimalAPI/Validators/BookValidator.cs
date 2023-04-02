using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CursminimalAPI.Validators;

public class BookValidator
{
    public BookValidator()
    {
        RuleFor(book => book.Isbn);
    }
}
