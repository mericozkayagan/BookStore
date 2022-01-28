
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DbOperation
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DbOperation.Context(serviceProvider.GetRequiredService<DbContextOptions<DbOperation.Context>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"

                    }, new Genre
                    {
                        Name = "Sci Fi"

                    }, new Genre
                    {
                        Name = "Romance"

                    }
                    );
                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1, // personal growth
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 1, 12)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2, // Sci fi
                        PageCount = 250,
                        PublishDate = new DateTime(2001, 8, 6)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 2, // Sci fi
                        PageCount = 300,
                        PublishDate = new DateTime(2001, 11, 6)
                    });
                context.Authors.AddRange(
                    new Author
                    {
                        AuthorName = "Meriç Özkayagan",
                        AuthorBirth = new DateTime(2001, 11, 11),
                    },
                    new Author
                    {
                        AuthorName = "Derin Özka",
                        AuthorBirth = new DateTime(2001, 11, 9),
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
