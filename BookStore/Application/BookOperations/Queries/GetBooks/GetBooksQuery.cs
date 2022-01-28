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
    public class GetBooksQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public GetBooksQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _context.Books.Include(x=>x.Genre).OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
            
            return vm;
        }
    }
    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
