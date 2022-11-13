using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Api.Data;
using Span.Culturio.Api.Helpers;
using Span.Culturio.Api.Models.Authorization;
using Span.Culturio.Api.Models.User;

namespace Span.Culturio.Api.Services.User {
    public class UserService : IUserService {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(DataContext context, IMapper mapper, IConfiguration configuration) {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<UserDto> GetUserAsync(int id) {
            var user = await _context.Users.FindAsync(id);
            if (user == null) {
                return null;
            }
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<UsersDto> GetUsersAsync(int pageSize, int pageIndex) {
            var users = await _context.Users.Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();

            var usersDtos = _mapper.Map<IEnumerable<UserDto>>(users);

            return new UsersDto {
                Data = usersDtos,
                TotalCount = usersDtos.Count()
            };
        }

        public async Task<TokenDto> Login(LoginDto loginUserDto) {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == loginUserDto.Username);

            if (user is null) return null;

            if (!UserHelper.VerifyPasswordHash(loginUserDto.Password, user.PasswordHash, user.PasswordSalt)) return null;

            var token = UserHelper.CreateToken(loginUserDto, _configuration.GetSection("Jwt:Key").Value);

            return new TokenDto { Token = token };
        }

        public async Task<UserDto> RegisterUser(RegisterUserDto registerUserDto) {
            var user = _mapper.Map<Data.Entities.User>(registerUserDto);

            if (user is null) return null;

            UserHelper.CreatePasswordHash(registerUserDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Add(user);
            await _context.SaveChangesAsync();

            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
