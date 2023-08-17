using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using password_manager_api.Models;
using password_manager_api.Repositories.PasswordRepository;

namespace password_manager_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordRepository _repository;
        public PasswordController(IPasswordRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public List<PasswordModel> GetPasswords([FromBody] UserModel user)
        {
            return _repository.GetPasswords(user);
        }
    }
}
