using BookStore.Application.AuthorOperations.Commands.CreateAuthor;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.UnitTests.Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("a")] 

        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);
            command.Model = new CreateAuthorModel() { AuthorBirth = DateTime.Now.AddYears(-3), AuthorName = name };

            CreateAuthorCommandValidator validations = new CreateAuthorCommandValidator();
            var result = validations.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
