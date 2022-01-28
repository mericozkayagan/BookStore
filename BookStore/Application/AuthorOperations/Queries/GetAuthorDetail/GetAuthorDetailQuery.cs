using AutoMapper;

using BookStore.DbOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int AuthorID { get; set; }

        public GetAuthorDetailQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.AuthorId == AuthorID);
            if(author is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }
            AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(author);
            return vm;
        }
    }
    public class AuthorDetailViewModel
    {
        public int AuthorName { get; set; }
        public DateTime AuthorBirth { get; set; }
    }
}
