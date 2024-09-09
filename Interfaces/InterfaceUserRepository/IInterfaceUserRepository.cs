using api.Models;

namespace api.Interfaces.InterfaceRepository
{
    public interface IInterfaceUserRepository
    {
        List<User> FindAll(int pageNumber);
        User FindById(int id);
        List<User> FindByName(string nome, int pageNumber);
        void Create(User userParamametro);
        void Update(int id, User userParamametro);
        void Delete(int id);
        User Login(string email, string senha);
    }
}