using BookStore.Application.GenreOperations.Commands.DeleteGenre;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.UnitTests.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId = 0;

            DeleteGenreCommandValidator validations = new DeleteGenreCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
