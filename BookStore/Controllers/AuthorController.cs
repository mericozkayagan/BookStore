using AutoMapper;
using BookStore.Application.AuthorOperations.Commands.CreateAuthor;
using BookStore.Application.AuthorOperations.Commands.DeleteAuthor;
using BookStore.Application.AuthorOperations.Commands.UpdateAuthor;
using BookStore.Application.AuthorOperations.Commands.UpdateBook;
using BookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStore.Application.AuthorOperations.Queries.GetAuthors;
using BookStore.DbOperation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public AuthorController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("id")]
        public IActionResult GetAuthorDetail(int id)
        {
            AuthorDetailViewModel result;

            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            query.AuthorID = id;
            GetAuthorDetailValidator validations = new GetAuthorDetailValidator();
            validations.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);

        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = newAuthor;
            CreateAuthorCommandValidator validations = new CreateAuthorCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();

            return Ok();
            
        }

        [HttpPut("id")]
        public IActionResult UpdateAuthor([FromBody] UpdateAuthorModel updatedAuthor, int id)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Model = updatedAuthor;
            command.AuthorID = id;
            UpdateAuthorCommandValidator validations = new UpdateAuthorCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            DeleteAuthorCommandValidator validations = new DeleteAuthorCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
