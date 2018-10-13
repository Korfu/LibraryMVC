using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Database
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Author).NotNull();
            RuleFor(x => x.Title).Length(1, 50).NotNull();
            RuleFor(x => x.ProductionYear).ExclusiveBetween(1, DateTime.Now.Year);
        }
    }
}
