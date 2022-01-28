using BookStore.Application.AuthorOperations.Commands.DeleteAuthor;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.UnitTests.Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputIsGıven_Validator_ShouldReturnError()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            command.AuthorId = 0;

            DeleteAuthorCommandValidator validations = new DeleteAuthorCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
