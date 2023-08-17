using password_manager_api.Models;

namespace password_manager_api.Repositories.PasswordRepository
{
    public interface IPasswordRepository
    {
        public List<PasswordModel> GetPasswords(UserModel user);
    }
}
