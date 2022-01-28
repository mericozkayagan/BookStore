using AutoMapper;
using BookStore.BookOperations;
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
   public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange - Hazırlık
            var book = new Book() { Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount = 100, PublishDate = new DateTime(1990, 01, 10), GenreId = 1 };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() { Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn" };

            //act & assert Çalıştırma - Doğrulama
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");            
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            CreateBookModel model = new CreateBookModel() { Title = "Hobbit", PageCount = 1000, PublishDate = new DateTime(1990, 01, 10), GenreId = 1 };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var book = _context.Books.SingleOrDefault(x => x.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);            
            book.GenreId.Should().Be(model.GenreId);
        }
    }
}
