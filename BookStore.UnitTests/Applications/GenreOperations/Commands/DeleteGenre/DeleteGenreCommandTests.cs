using AutoMapper;
using BookStore.Application.GenreOperations.Commands.DeleteGenre;
using BookStore.DbOperation;
using BookStore.Entities;
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
    public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly Context context;
        private readonly IMapper mapper;
        public int GenreId { get; set; }

        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenGenreIdCannotBeFound_InvalidOperationException_ShouldBeReturn()
        {
            var genre = new Genre() { Name = "test123", IsActive = true };
            context.Genres.Add(genre);
            context.SaveChanges();
            GenreId = 1;

            DeleteGenreCommand command = new DeleteGenreCommand(context);

            FluentActions
               .Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü bulunamadı");
        }
    }
}
