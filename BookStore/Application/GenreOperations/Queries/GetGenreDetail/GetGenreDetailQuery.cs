﻿using AutoMapper;
using BookStore.DbOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GetGenreDetailQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive == true && x.Id == GenreId);
            if(genre is null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı");
            }
            return _mapper.Map<GenreDetailViewModel>(genre);
        }
        public class GenreDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
