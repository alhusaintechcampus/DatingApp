using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _contaxt;
        private readonly IMapper _mapper;
        public UserRepository(DataContext contaxt, IMapper mapper)
        {
            _mapper = mapper;
            _contaxt = contaxt;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            // projetTo will only slect from database field requred in memberDto
            // will not select all fileds then map. it is optimal.
            // also in projectTo no need to use Include<photos>
            // it will do automatecally;
            return await _contaxt.Users
            .Where( user => user.UserName == username )
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
           return await _contaxt.Users
           .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
           .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _contaxt.Users
            .FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string usernaame)
        {
            return await _contaxt.Users
            .Include(p => p.Photos) // this eager loading to get related photos table
            .SingleOrDefaultAsync(user => user.UserName == usernaame);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _contaxt.Users
            .Include(p => p.Photos)//this eager loading to get related photos table
            .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            // return true if 1 or more changes is been saved, else false
            return await _contaxt.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _contaxt.Entry(user).State = EntityState.Modified;
        }
    }
}