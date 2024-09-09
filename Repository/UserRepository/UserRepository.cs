using api.Data;
using api.Interfaces.InterfaceRepository;
using api.Models;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace api.Repository.UserRepository
{
    public class UserRepository : IInterfaceUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) {
            _context = context;
        }
        public List<User> FindAll(int pageNumber)
        {
            int pageSize = 3;
            return _context.User.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public User FindById(int id)
        {
            return _context.User.FirstOrDefault(user => user.Id == id);
        }

        public List<User> FindByName(string nome, int pageNumber)
        {
            int pageSize = 3;
            return _context.User.Where(x => x.Nome.ToUpper().Contains(nome.ToUpper())).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public void Create(User userParametro)
        {
            _context.User.Add(userParametro);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.User.FirstOrDefault(user => user.Id == id);

            _context.Remove(user);
            _context.SaveChanges();

        }

        public void Update(int id, User userParametro)
        {
            var user = _context.User.FirstOrDefault(user => user.Id == id);
            user.Nome = userParametro.Nome;
            user.Senha = userParametro.Senha;
            user.Email = userParametro.Email;

            _context.Update(user);
            _context.SaveChanges();

        }
        public User Login(string email, string senha)
        {
            return _context.User.FirstOrDefault(user => user.Email == email && user.Senha == senha);
        }
    }
}
