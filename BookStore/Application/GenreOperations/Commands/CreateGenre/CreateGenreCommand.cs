
using AutoMapper;
using BookStore.DbOperation;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            //var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);           
            //genre = new Entities.Genre();
            //var existingBook = _context.Genres.Contains(genre);
            //if (existingBook is true)
            //{
            //    throw new InvalidOperationException("Tür zaten mevcut");
            //}
            //genre.Name = Model.Name;
            //_context.Genres.Add(genre);
            //_context.SaveChanges();
            var genre = _context.Genres.FirstOrDefault(x => x.Name == Model.Name);
            if (genre is not null)
            {
                throw new InvalidOperationException("Tür zaten mevcut");
            }
            genre = _mapper.Map<Genre>(Model);

            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }
    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
