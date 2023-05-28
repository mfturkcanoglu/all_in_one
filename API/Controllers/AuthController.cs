using ApplicationCore.Dto.Request;
using ApplicationCore.Dto.Response;
using ApplicationCore.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/authorize")]
public class AuthController : ControllerBase
{
    private readonly IUserService userService;

    public AuthController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<ResponseDto<AuthResponseDto>>> Login([FromBody] LoginRequestDto loginRequestDto)
    {
        return Ok(new ResponseDto<AuthResponseDto>(await userService.LoginUser(loginRequestDto)));
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<ResponseDto<AuthResponseDto>>> Register([FromBody] UserSignUpRequestDto signUpRequestDto)
    {
        return Ok(new ResponseDto<AuthResponseDto>(await userService.Register(signUpRequestDto)));
    }
}
