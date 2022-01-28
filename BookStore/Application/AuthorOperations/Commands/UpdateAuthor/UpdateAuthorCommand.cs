using AutoMapper;
using BookStore.DbOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.AuthorOperations.Commands.UpdateBook
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorModel Model { get; set; }
        private readonly IContext _context;        
        
        public int AuthorID { get; set; }
        

        public UpdateAuthorCommand(IContext context)
        {
            _context = context;           
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.AuthorId == AuthorID);
            if (author is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }
            author.AuthorBirth = Model.AuthorBirth != default ? Model.AuthorBirth : author.AuthorBirth;
            author.AuthorName = Model.AuthorName != default ? Model.AuthorName : author.AuthorName;            
            _context.SaveChanges();

        }
        
    }
    public class UpdateAuthorModel
    {
        public string AuthorName { get; set; }
        public DateTime AuthorBirth { get; set; }
    }
}
