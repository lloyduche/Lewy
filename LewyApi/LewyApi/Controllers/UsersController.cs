using AutoMapper;
using Lewy.Core.DTOs;
using Lewy.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        [HttpGet("UserName/{UserName}")]
        public async Task<IActionResult> GetUserbyUsername(string username)
        {

            var user = await _userRepository.GetMemberAsync(username);

            return Ok(user);

        }

        [HttpPut("Update-Member")]
        public async Task<IActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userRepository.GetUserByUsernameAsync(username);

            _mapper.Map(memberUpdateDto,user);
            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to Update User");

        }

    }
}
