using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {            
            RuleFor(x => x.Model.AuthorName).NotEmpty().MinimumLength(2);
        }
    }
}
