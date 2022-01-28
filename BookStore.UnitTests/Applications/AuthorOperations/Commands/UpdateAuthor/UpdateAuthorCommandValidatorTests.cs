using BookStore.Application.AuthorOperations.Commands.UpdateAuthor;
using BookStore.Application.AuthorOperations.Commands.UpdateBook;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.UnitTests.Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("a")]
        [InlineData("")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name)
        {
            UpdateAuthorModel Model = new UpdateAuthorModel() { AuthorBirth = DateTime.Now.AddYears(-2), AuthorName = name };

            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.Model = Model;
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
