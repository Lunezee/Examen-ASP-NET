using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationExam
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserGrid();
            }
        }

        private void BindUserGrid()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString))
            {
                string query = "SELECT UserID, FirstName, LastName, Login FROM Users";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            BindUserGrid();
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);
            string firstName = ((TextBox)gvUsers.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string lastName = ((TextBox)gvUsers.Rows[e.RowIndex].Cells[2].Controls[0]).Text;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString))
            {
                string query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            gvUsers.EditIndex = -1;
            BindUserGrid();
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString))
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            BindUserGrid();
        }

    }
}