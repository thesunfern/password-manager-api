using Microsoft.Extensions.Options;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using password_manager_api.Models;
using password_manager_api.Utilities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace password_manager_api.Repositories.PasswordRepository
{
    public class PasswordRepository : IPasswordRepository
    {
        private ConnectionStrings _connectionStrings;
        public PasswordRepository(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        public List<PasswordModel> GetPasswords(UserModel user)
        {
            string connection = _connectionStrings.SQLConnection;
            DataTable dt = new DataTable();
            List<PasswordModel> passwordsList = new List<PasswordModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connection)) {
                using (SqlCommand sqlCommand = new SqlCommand("GetPasswords", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", user.UserId);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                }
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                PasswordModel passwordModel = new PasswordModel
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Password = Convert.ToString(row["Password"]),
                    Name = Convert.ToString(row["Name"]),
                    URL = Convert.ToString(row["URL"]),
                    Description = Convert.ToString(row["Description"]),
                    UserId = Convert.ToString(row["UserId"])
                };
                passwordsList.Add(passwordModel);
            }

            return passwordsList;
        }

        public int AddPassword(PasswordModel password)
        {
            int result = 0;
            string connection = _connectionStrings.SQLConnection;
            DataTable dt = new DataTable();
            List<PasswordModel> passwordsList = new List<PasswordModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                using (SqlCommand sqlCommand = new SqlCommand("AddPassword", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Password", password.Password);
                    sqlCommand.Parameters.AddWithValue("@Name", password.Name);
                    sqlCommand.Parameters.AddWithValue("@URL", password.URL);
                    sqlCommand.Parameters.AddWithValue("@Description", password.Description);
                    sqlCommand.Parameters.AddWithValue("@UserId", password.UserId);

                    SqlParameter outParam = new SqlParameter("@Result", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.Add(outParam);

                    sqlCommand.ExecuteNonQuery();

                    result = Convert.ToInt32(sqlCommand.Parameters["@Result"].Value);
                }
            }

            return result;

        }


    }
}
