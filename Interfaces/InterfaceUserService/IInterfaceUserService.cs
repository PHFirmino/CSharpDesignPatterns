using api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace api.Interfaces.InterfaceService
{
    public interface IInterfaceUserService
    {
        List<User> FindAll(int pageNumber);
        User FindById(int id);
        List<User> FindByName(string nome, int pageNumber);
        void Create(User userParametro);
        void Update(int id, User userParametro);
        void Delete(int id);
        string Login(string email, string senha);
    }
}
