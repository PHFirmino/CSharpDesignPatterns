using api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Interfaces.InterfaceAuthService
{
    public interface IInterfaceAuthService
    {
        string GenerateToken(User user);
        ClaimsIdentity GenerateClaims(User user);
    }
}
