using BookStore.DbOperation;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this Context context)
        {
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
        }
    }
}
