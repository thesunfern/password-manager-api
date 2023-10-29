using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using password_manager_api.Models;
using password_manager_api.Repositories.UserRepository;
using System.Data;

namespace password_manager_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [Route("AuthenticateUser")]
        [HttpPost]
        public IActionResult AuthenticateUser([FromBody] UserModel model)
        {
            try
            {
                DataTable userDt = _repository.AuthenticateUser(model);
                if (userDt.Rows.Count == 0)
                {
                    return NotFound("User Not found");
                }
                DataRow row = userDt.Rows[0];
                UserModel user = new UserModel
                {
                    UserId = Convert.ToString(row["UserId"]),
                    Username = Convert.ToString(row["Username"]),
                    //LoginPassword = Convert.ToString(row["LoginPassword"]),
                    Email = Convert.ToString(row["Email"])

                };
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();                
            }
        }
    }
}
