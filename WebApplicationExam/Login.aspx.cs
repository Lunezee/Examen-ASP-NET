using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace YourNamespace
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            // Hacher le mot de passe saisi par l'utilisateur
            string passwordHash = ComputeSha256Hash(password);

            // Vérifier si les informations de connexion sont correctes
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString))
            {
                string query = "SELECT COUNT(1) FROM Users WHERE Login = @Login AND PasswordHash = @PasswordHash";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    // Si les informations de connexion sont correctes, rediriger vers la page d'accueil
                    Session["UserLogin"] = login;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    // Afficher un message d'erreur si la connexion échoue
                    Response.Write("<script>alert('Login ou mot de passe incorrect');</script>");
                }
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
