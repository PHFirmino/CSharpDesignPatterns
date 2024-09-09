using api.Interfaces.InterfaceRepository;
using api.Interfaces.InterfaceService;
using api.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using api.Interfaces.InterfaceAuthService;
using api.Interfaces.HashPassword;

namespace api.Services.UserService
{
    public class UserService : IInterfaceUserService
    {
        private readonly IInterfaceUserRepository _repository;
        private readonly IInterfaceAuthService _authService;
        private readonly IInterfaceHashPassword _hashPassword;
        public UserService(IInterfaceUserRepository repository, IInterfaceAuthService authService, IInterfaceHashPassword hashPassword) { 
            _repository = repository;
            _authService = authService;
            _hashPassword = hashPassword;
        }
        public List<User> FindAll(int pageNumber)
        {

            return _repository.FindAll(pageNumber);
        }

        public User FindById(int id)
        {
            return _repository.FindById(id);
        }

        public List<User> FindByName(string nome, int pageNumber)
        {
            return _repository.FindByName(nome, pageNumber);
        }

        public void Create(User userParametro)
        {
            userParametro.Senha = _hashPassword.HashPassword(userParametro.Senha);
            _repository.Create(userParametro);
        }

        public void Delete(int id)
        {
           _repository.Delete(id);
        }

        public void Update(int id, User userParametro)
        {

           _repository.Update(id, userParametro);
        }
        public string Login(string email, string senha)
        {
           senha = _hashPassword.HashPassword(senha);
           return _authService.GenerateToken(_repository.Login(email, senha));
        }
    }
}
