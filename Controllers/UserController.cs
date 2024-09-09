using api.Data;
using api.Interfaces.InterfaceService;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IInterfaceUserService _userService;

        public UserController(IInterfaceUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("/UserFindAll")]
        [Authorize]
        public List<User> FindAll([FromQuery] int pageNumber = 1)
        {
            return _userService.FindAll(pageNumber);
        }

        [HttpGet("/User/{id}")]
        [Authorize]
        public User FindById([FromRoute]int id)
        {
            return _userService.FindById(id);
        }

        [HttpGet("/UserFindByName")]
        [Authorize]
        public List<User> FindByName([FromQuery] string nome, [FromQuery] int pageNumber = 1) {
            return _userService.FindByName(nome, pageNumber);
        }

        [HttpPost("/User")]
        [Authorize]
        public IActionResult Create([FromBody]User user)
        {
            try
            {
                _userService.Create(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("/User/{id}")]
        [Authorize]
        public IActionResult Update([FromRoute]int id, [FromBody]User user)
        {
            try
            {
                _userService.Update(id, user);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("/User")]
        [Authorize]
        public IActionResult Delete([FromBody] int id)
        {
            try
            {
                _userService.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("/Auth/Login")]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                return Ok(_userService.Login(user.Email, user.Senha));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
