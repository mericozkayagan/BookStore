
using BookStore.DbOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly IContext _context;
        public int AuthorId { get; set; }

        public DeleteAuthorCommand(IContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.FirstOrDefault(x => x.AuthorId == AuthorId);
            if(author is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

    }
}
