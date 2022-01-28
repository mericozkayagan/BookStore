using AutoMapper;
using BookStore.Application.GenreOperations.Commands.CreateGenre;
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

namespace BookStore.UnitTests.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenInvalidInputsAreGiven_InvalidOperationException_ShouldReturn()
        {
            var genre = new Genre() {IsActive = true, Name = "test123" };
            context.Add(genre);
            context.SaveChanges();
            
            CreateGenreCommand command = new CreateGenreCommand(context,mapper);
            CreateGenreModel Model = new CreateGenreModel() { Name = "test123" };
            command.Model = Model;

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Tür zaten mevcut");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
        {
            CreateGenreCommand command = new CreateGenreCommand(context, mapper);
            CreateGenreModel Model = new CreateGenreModel() { Name = "test123"};
            command.Model = Model;
            FluentActions
                .Invoking(() => command.Handle());
            var genre = context.Genres.FirstOrDefault(x => x.Name == Model.Name);
           
        }
    }
}
