using DatingApp.DTOs;
using DatingApp.Entities;
using DatingApp.Interfaces;
namespace DatingApp.Extensions
{
    public static class AppUserExtensions
    {
        public static UserDTO ToDTO(this AppUser user, ITokenService tokenService)
        {
            return new UserDTO
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };
        }

    }
}
