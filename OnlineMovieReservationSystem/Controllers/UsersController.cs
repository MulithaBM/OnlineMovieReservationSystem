using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Data;
using OnlineMovieReservationSystem.Dtos.User;
using OnlineMovieReservationSystem.Models;

namespace OnlineMovieReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UsersController(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegistrationDto newUser)
        {
            var response = new ServiceResponse<int>();

            if(await _context.Users.AnyAsync(u => u.Email.ToLower() == newUser.Email.ToLower()))
            {
                response.Success = false;
                response.Message = "User already exists";
                
                return BadRequest(response);
            }

            return Ok(response);
        }
    }   
}
