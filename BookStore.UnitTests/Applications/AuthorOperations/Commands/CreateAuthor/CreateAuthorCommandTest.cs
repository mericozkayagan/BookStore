using AutoMapper;
using BookStore.Application.AuthorOperations.Commands.CreateAuthor;
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

namespace BookStore.UnitTests.Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public CreateAuthorCommandTest(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenAlreadyExistAuthorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var author = new Author() { AuthorName = "test", AuthorBirth = new DateTime(2001,01,01)};
            context.Add(author);
            context.SaveChanges();

            CreateAuthorCommand command = new CreateAuthorCommand(context,mapper);
            CreateAuthorModel model = new CreateAuthorModel() { AuthorName = "test" , AuthorBirth = new DateTime(2001, 01, 01) };
            command.Model = model;

            FluentActions
                .Invoking(() => command.Handle()).Invoke();
            author.Should().NotBeNull();
            author.AuthorBirth.Should().Be(model.AuthorBirth);
            author.AuthorName.Should().Be(model.AuthorName);            
        }

        [Fact]
        public void WhenAllValidInputsAreGiven_Author_ShouldBeCreated()
        {
            CreateAuthorCommand command = new CreateAuthorCommand(context, mapper);            
            CreateAuthorModel model = new CreateAuthorModel() { AuthorName = "test1", AuthorBirth = new DateTime(2001, 01, 01)};
            command.Model = model;

            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            var author = context.Authors.SingleOrDefault(x => x.AuthorName == model.AuthorName);
            author.AuthorBirth.Should().Be(model.AuthorBirth);            

        }
    }
}
