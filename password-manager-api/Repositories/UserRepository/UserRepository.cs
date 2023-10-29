using Microsoft.Extensions.Options;
using password_manager_api.Models;
using password_manager_api.Utilities;
using System.Data.SqlClient;
using System.Data;

namespace password_manager_api.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private ConnectionStrings _connectionStrings;
        private string _sqlConnection;
        public UserRepository(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
            _sqlConnection = _connectionStrings.SQLConnection;
        }

        public DataTable AuthenticateUser(UserModel model)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("AuthenticateUser", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@UserId", model.UserId);
                        sqlCommand.Parameters.AddWithValue("@LoginPassword", model.LoginPassword);
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception)
            {
            }

            //UserModel user = new UserModel
            //{
            //    UserId = dt.Rows[""],
            //};
            return dt;
        }
    }
}
