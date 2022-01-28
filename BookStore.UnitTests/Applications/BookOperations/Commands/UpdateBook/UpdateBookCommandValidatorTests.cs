using BookStore.BookOperations;
using BookStore.BookOperations.UpdateBook;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.UnitTests.Applications.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0, 0, "")]
        [InlineData(1, 0, "")]
        [InlineData(1, 1, "")]
        [InlineData(0, 1, "")]
        [InlineData(0, 0, "a")]
        [InlineData(0, 1, "a")]
        [InlineData(1, 0, "a")]
        [InlineData(1, 1, "a")]
        [InlineData(0, 0, "aa")]
        [InlineData(0, 1, "aa")]
        [InlineData(1, 0, "aa")]        
        public void WhenInValidInputsAreGiven_Validator_ShouldReturnErrors(int bookId, int genreId, string Title)
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookViewModel() { Title = Title, GenreId = genreId };
            command.BookId = bookId;

            UpdateBookValidator validations = new UpdateBookValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}

