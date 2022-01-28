using AutoMapper;
using BookStore.DbOperation;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var author = _context.Authors.FirstOrDefault(x => x.AuthorName == Model.AuthorName);           
            author = _mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }
    public class CreateAuthorModel
    {
        public string AuthorName { get; set; }
        public DateTime AuthorBirth { get; set; }
    }
}
