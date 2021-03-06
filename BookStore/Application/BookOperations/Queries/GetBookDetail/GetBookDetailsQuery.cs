using AutoMapper;
using BookStore.Common;
using BookStore.DbOperation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations
{
    public class GetBookDetailsQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookDetailsQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = _context.Books.Include(x=>x.Genre).Where(x => x.Id == BookId).FirstOrDefault();
            if(book is null)
            {
                throw new InvalidOperationException("Böyle bir kitap bulunamadı");
            }
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
            
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
