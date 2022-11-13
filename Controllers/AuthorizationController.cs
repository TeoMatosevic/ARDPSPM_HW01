using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Api.Models.Authorization;
using Span.Culturio.Api.Models.User;
using Span.Culturio.Api.Services.User;

namespace Span.Culturio.Api.Controllers {
    [Tags("Auth")]
    [Route("[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase {

        private readonly IUserService _userService;
        private readonly IValidator<RegisterUserDto> _validator;
        public AuthorizationController(IUserService userService, IValidator<RegisterUserDto> validator) {
            _userService = userService;
            _validator = validator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUser(RegisterUserDto registerUserDto) {
            ValidationResult result = _validator.Validate(registerUserDto);
            if (!result.IsValid) return BadRequest("Validation error");

            var user = await _userService.RegisterUser(registerUserDto);
            if (user is null) return BadRequest("Validation error");

            return Ok("Successful response");
        }
        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginUserDto) {
            var token = await _userService.Login(loginUserDto);
            if (token is null) return BadRequest("Bad username or password");

            return Ok(token);
        }
    }
}
