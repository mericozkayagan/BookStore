using AutoMapper;
using BookStore.Application.UserOperations.Commands.CreateToken;
using BookStore.Application.UserOperations.Commands.CreateUser;
using BookStore.Application.UserOperations.Commands.RefreshToken;
using BookStore.DbOperation;
using BookStore.TokenOperations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.Application.UserOperations.Commands.CreateToken.CreateTokenCommand;
using static BookStore.Application.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController : Controller
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public UserController(IContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            command.Model = newUser;
            command.Handle();

            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper,_configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }
    }
}
