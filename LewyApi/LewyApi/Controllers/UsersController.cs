using AutoMapper;
using Lewy.Core.DTOs;
using Lewy.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LewyApi.Controllers
{
    [Authorize]
    public class UsersController : BaseApiContoller
    {
        
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
                            
        }
         
        [HttpGet("GetUsers")]
       
        public async Task<IActionResult> GetUsers()
        {

            var users = await _userRepository.GetMembersAsync();

            return Ok(users);
            
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {

            var user =await _userRepository.GetUserByIdAsync(id);

            var userToReturn = _mapper.Map<MemberDto>(user);

            return Ok(userToReturn);

        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username)
        {

            var user = await _userRepository.GetMemberAsync(username);

            return Ok(user);

        }

    }
}
