
using BookStore.DbOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations
{
    public class DeleteBookCommand
    {
        private readonly IContext _context;
        public int BookId { get; set; }
        public DeleteBookCommand(IContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı");
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
