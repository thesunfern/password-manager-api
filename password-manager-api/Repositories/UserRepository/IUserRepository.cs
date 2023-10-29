using password_manager_api.Models;
using System.Data;

namespace password_manager_api.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public DataTable AuthenticateUser(UserModel model);
    }
}
