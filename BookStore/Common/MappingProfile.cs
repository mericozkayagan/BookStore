using AutoMapper;
using BookStore.Application.AuthorOperations.Commands.CreateAuthor;
using BookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStore.Application.AuthorOperations.Queries.GetAuthors;
using BookStore.Application.GenreOperations.Commands.CreateGenre;
using BookStore.BookOperations;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.Application.GenreOperations.Queries.GetGenreDetail.GetGenreDetailQuery;
using static BookStore.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;
using static BookStore.Application.UserOperations.Commands.CreateUser.CreateUserCommand;
using static BookStore.BookOperations.CreateBookCommand;

namespace BookStore.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateAuthorModel,Author>();
            CreateMap<Author, AuthorDetailViewModel>();
            CreateMap<Author, AuthorsViewModel>();
            CreateMap<CreateUserModel, User>();
            CreateMap<CreateGenreModel, Genre>();
        }
    }
}
