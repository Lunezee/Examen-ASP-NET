using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace WebApplicationExam
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string dateOfBirth = txtDateOfBirth.Text;
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            // Hacher le mot de passe avant de le stocker en base de données
            string passwordHash = ComputeSha256Hash(password);

            // Insérer l'utilisateur dans la base de données
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString))
            {
                string query = "INSERT INTO Users (FirstName, LastName, DateOfBirth, Login, PasswordHash) VALUES (@FirstName, @LastName, @DateOfBirth, @Login, @PasswordHash)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                conn.Open();
                cmd.ExecuteNonQuery();

                // Rediriger vers la page de connexion après l'inscription
                Response.Redirect("Login.aspx");
            }
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}