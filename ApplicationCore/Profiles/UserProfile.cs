using ApplicationCore.Dto.Request;
using AutoMapper;
using Infrastructure.Model;

namespace ApplicationCore.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserSignUpRequestDto>();
    }
}