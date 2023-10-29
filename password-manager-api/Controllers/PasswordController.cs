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

        [HttpPost]
        [Route("GetPasswords")]
        public IActionResult GetPasswords([FromBody] UserModel user)
        {
            try
            {
                List<PasswordModel> passwords = _repository.GetPasswords(user);
                return Ok(passwords);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("AddPassword")]
        public IActionResult AddPassword([FromBody] PasswordModel password)
        {
            try
            {
                if (password == null)
                {
                    return BadRequest("Invalid Request");
                }

                password.URL = string.IsNullOrWhiteSpace(password.URL) ? null : password.URL;
                password.Description = string.IsNullOrWhiteSpace(password.Description) ? null : password.Description;


                int passwords = _repository.AddPassword(password);
                return Ok(passwords);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
