using BookStore.Application.GenreOperations.Commands.CreateGenre;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.UnitTests.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("a")]
        [InlineData("")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name)
        {
            CreateGenreModel Model = new CreateGenreModel() { Name=name };

            CreateGenreCommand command = new CreateGenreCommand(null,null);
            command.Model = Model;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
