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

namespace BookStore.UnitTests.Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly Context context;
        private readonly IMapper mapper;
        public int BookId { get; set; }

        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenBookIdCannotBeFound_InvalidOperationException_ShouldBeReturn()
        {            
            var book = new Book() { Title = "Test", GenreId = 1, PageCount = 100, Id = 0, PublishDate = DateTime.Now.AddYears(-1)};
            context.Books.Add(book);
            context.SaveChanges();
            BookId = 1;

            DeleteBookCommand command = new DeleteBookCommand(context);

            FluentActions
               .Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı");
        }
    }
}
