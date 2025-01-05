using OnionArch.Application.DTOs;

namespace OnionArch.Application.Abstractions
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int minute);
        string CreateRefreshToken();
    }
}
