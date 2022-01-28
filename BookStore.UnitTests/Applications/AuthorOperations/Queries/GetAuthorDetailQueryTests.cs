using AutoMapper;
using BookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
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

namespace BookStore.UnitTests.Applications.AuthorOperations.Queries
{
    public class GetAuthorDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public GetAuthorDetailQueryTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }
        public int AuthorId { get; set; }

        [Fact]
        public void WhenAuthorIdCannotBeFound_InvalidOperationException_ShouldReturn()
        {
            var author = new Author() { AuthorBirth = DateTime.Now.AddYears(-2), AuthorId = 1, AuthorName = "test123" };
            context.Add(author);

            GetAuthorDetailQuery query = new GetAuthorDetailQuery(context,mapper);
            query.AuthorID = 2;

            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");
        }
    }
}
