using AutoMapper;
using BookStore.Application.AuthorOperations.Commands.UpdateBook;
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

namespace BookStore.UnitTests.Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly Context context;
        private readonly IMapper mapper;
        public int AuthorId { get; set; }

        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenGivenIdIsNotNotFound_InvalidOperationException_ShouldReturn()
        {
            var author = new Author() { AuthorBirth = new DateTime(2001, 12, 12), AuthorId = 1, AuthorName = "Test123" };
            context.Add(author);
            AuthorId = 2;

            UpdateAuthorCommand command = new UpdateAuthorCommand(context);
            command.Model = new UpdateAuthorModel() { AuthorBirth = new DateTime(2001, 12, 12), AuthorName = "Test123" };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");

        }
    }
}
