using BookStore.DbOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this Context context)
        {
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
        }
    }
}
