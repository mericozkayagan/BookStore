using BookStore.Application.AuthorOperations.Commands.UpdateBook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {           
            RuleFor(x => x.Model.AuthorName).NotEmpty().MinimumLength(2);
        }
    }
}
