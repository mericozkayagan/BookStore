using AutoMapper;
using BookStore.Application.GenreOperations.Commands.UpdateGenre;
using BookStore.DbOperation;
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
   public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly Context context;
        private readonly IMapper mapper;
        public int GenreId { get; set; }

        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenGenreIdCannotBeFound_InvalidOperationException_ShouldBeReturn()
        {
            var book = new Book() { Title = "Test", GenreId = 7 };
            context.Books.Add(book);
            context.SaveChanges();
            GenreId = 11;

            UpdateGenreCommand command = new UpdateGenreCommand(context);
            command.Model = new UpdateGenreModel() {Name="test123123" };

            FluentActions
               .Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü bulunamadı");
        }
    }
}
