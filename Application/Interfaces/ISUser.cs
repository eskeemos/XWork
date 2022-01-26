using Application.Dtos.UserDtos;

namespace Application.Interfaces
{
    public interface ISUser
    {
        int PostUser(UserRegisterDto dto);
        string GenerateJwt(UserLoginDto dto);
    }
}
