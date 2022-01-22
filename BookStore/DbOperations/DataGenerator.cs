using BookStore.DbOperation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
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
                context.SaveChanges();
            }
        }
    }
}
