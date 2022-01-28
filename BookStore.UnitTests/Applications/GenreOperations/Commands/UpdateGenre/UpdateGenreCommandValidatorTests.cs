using BookStore.Application.GenreOperations.Commands.UpdateGenre;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.UnitTests.Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("a")]
        [InlineData("")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name)
        {
            UpdateGenreModel Model = new UpdateGenreModel() { Name=name,IsActive=true };

            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.Model = Model;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
