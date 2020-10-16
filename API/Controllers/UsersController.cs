using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository,      
        IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await _userRepository.GetMembersAsync();
       // var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
        // not allowed to tyoe return _mapper.Map<IEnumerable<MemberDto>>(users);
        // must assign to a variable then return in ok();
        return Ok(users);       
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
         return await _userRepository.GetMemberAsync(username);
    }


}
}