using BookStore.DbOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations
{
    public class UpdateBookCommand
    {
        private readonly Context _context;
        public int BookId { get; set; }
        public UpdateBookViewModel Model { get; set; }
        public UpdateBookCommand(Context context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == BookId);
            if (book == null)
            {
                throw new InvalidOperationException("Böyle bir kitap bulunamadı");
            }
            
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;            
            book.Title = Model.Title != default ? Model.Title : book.Title;
            _context.Update(book);
            _context.SaveChanges();                  
        }
    }
    public class UpdateBookViewModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }        
    }
}
