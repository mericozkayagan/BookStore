using BookStore.Common;
using BookStore.DbOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations
{
    public class GetBookDetailQuery
    {
        private readonly Context _context;
        public int BookId { get; set; }
        public GetBookDetailQuery(Context context)
        {
            _context = context;
        }
        public BookDetailViewModel Handle()
        {
            var book = _context.Books.Where(x => x.Id == BookId).FirstOrDefault();
            if(book is null)
            {
                throw new InvalidOperationException("Böyle bir kitap bulunamadı");
            }
            BookDetailViewModel vm = new BookDetailViewModel();
            vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/MMM/yyyy");
            vm.Title = book.Title;
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            return vm;
        }

        private string GenreEnum(object genreId)
        {
            throw new NotImplementedException();
        }
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
