using AutoMapper;
using BookStore.BookOperations;
using BookStore.BookOperations.CreateBook;
using BookStore.DbOperation;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static BookStore.BookOperations.CreateBookCommand;

namespace BookStore.UnitTests.Applications.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lord of the rings",0,0)]
        [InlineData("Lord of the rings",0,1)]
        [InlineData("Lord of the rings",100,0)]
        [InlineData("",0,0)]
        [InlineData("",100,1)]
        [InlineData("",0,1)]
        [InlineData("l",100,1)]
        [InlineData("lasd",100,0)]
        [InlineData("lasd",0,1)]
        [InlineData(" ",100,1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId)
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel() { Title = title, PageCount = pageCount, PublishDate = DateTime.Now.Date.AddYears(-1), GenreId = genreId };

            //act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel() { Title = "asdasd", PageCount = 100, PublishDate = DateTime.Now.Date.AddYears(-2), GenreId = 1 };
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
