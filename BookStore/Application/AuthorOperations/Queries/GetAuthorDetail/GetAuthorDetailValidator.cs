using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailValidator()
        {
            RuleFor(x => x.AuthorID).GreaterThan(0);
        }
    }
}
