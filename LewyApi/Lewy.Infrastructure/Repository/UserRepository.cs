using AutoMapper;
using AutoMapper.QueryableExtensions;
using Lewy.Core.DTOs;
using Lewy.Core.Entities;
using Lewy.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Lewy.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly LewyContext _context;
        private readonly IMapper _mapper;

        public UserRepository(LewyContext context,IMapper mapper)
        {
          _context = context;
            _mapper = mapper;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.AppUsers.Where(x => x.UserName == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
                 
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.AppUsers
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            
        }

        public async Task<IEnumerable<AppUser>> GetUserAsync()
        {
            return await _context.AppUsers
                .Include(x => x.Photos)
                .ToListAsync();
        }

      
        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.AppUsers.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.AppUsers
                .Include(x => x.Photos)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
