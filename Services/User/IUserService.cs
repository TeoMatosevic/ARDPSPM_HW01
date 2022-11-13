using Span.Culturio.Api.Models.Authorization;
using Span.Culturio.Api.Models.User;

namespace Span.Culturio.Api.Services.User {
    public interface IUserService {
        Task<UserDto> GetUserAsync(int id);
        Task<UsersDto> GetUsersAsync(int pageSIze, int pageIndex);
        Task<UserDto> RegisterUser(RegisterUserDto registerUserDto);
        Task<TokenDto> Login(LoginDto loginDto);
    }
}
