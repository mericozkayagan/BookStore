using AutoMapper;
using BookStore.Application.AuthorOperations.Commands.DeleteAuthor;
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

namespace BookStore.UnitTests.Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly Context context;
        
        public int AuthorId { get; set; }

        public DeleteAuthorCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            
        }
        [Fact]
        public void WhenAuthorIdCannotBeFound_InvalidOperationException_ShouldBeReturn()
        {
            var author = new Author() {AuthorBirth=DateTime.Now.AddYears(-2),AuthorName="test",AuthorId=2};
            context.Authors.Add(author);
            context.SaveChanges();
            AuthorId = 1;

            DeleteAuthorCommand command = new DeleteAuthorCommand(context);

            FluentActions
               .Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");
        }
    }
}
