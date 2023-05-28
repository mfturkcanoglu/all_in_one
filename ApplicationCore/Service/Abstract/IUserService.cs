using ApplicationCore.Dto.Request;
using ApplicationCore.Dto.Response;

namespace ApplicationCore.Service.Abstract;

public interface IUserService
{
    Task<AuthResponseDto> LoginUser(LoginRequestDto loginRequestDto);
    Task<AuthResponseDto> Register(UserSignUpRequestDto signUpRequestDto);
}