using AutoMapper;

using BookStore.DbOperation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authorList = _context.Authors.OrderBy(x => x.AuthorId).ToList();
            List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(authorList);
            return vm;
        }
    }
    public class AuthorsViewModel
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime AuthorBirth { get; set; }
    }
}
