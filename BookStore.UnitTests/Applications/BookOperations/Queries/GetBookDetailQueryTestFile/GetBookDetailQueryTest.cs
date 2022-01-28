using AutoMapper;
using BookStore.BookOperations;
using BookStore.DbOperation;
using BookStore.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BookStore.BookOperations.GetBookDetail;
using FluentAssertions;

namespace BookStore.UnitTests.Applications.BookOperations.Queries.GetBookDetailQuery
{
    public class GetBookDetailQueryTest:IClassFixture<CommonTestFixture>
    {
        private readonly Context context;
        private readonly IMapper mapper;
        public int BookId { get; set; }

        public GetBookDetailQueryTest(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenBookIdCannotBeFound_InvalidOperationException_ShouldBeReturn()
        {
            var book = new Book() { Title = "asdasd", GenreId = 1, Id = 0, PageCount = 100, PublishDate = DateTime.Now.AddYears(-1) };
            context.Books.Add(book);
            context.SaveChanges();

            BookId = 1;            

            GetBookDetailsQuery query = new GetBookDetailsQuery(context,mapper);

            FluentActions
                .Invoking(()=>query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir kitap bulunamadı");
        }
    }
}
