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
    public partial class ManageArticles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindArticleGrid();
            }
        }

        private void BindArticleGrid()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString))
            {
                string query = "SELECT * FROM Articles";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvArticles.DataSource = dt;
                gvArticles.DataBind();
            }
        }

        protected void btnAddArticle_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string description = txtDescription.Text;
            string category = txtCategory.Text;
            string gender = txtGender.Text;
            string color = txtColor.Text;
            string size = txtSize.Text;
            decimal price = decimal.Parse(txtPrice.Text);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString))
            {
                string query = "INSERT INTO Articles (Name, Description, Category, Gender, Color, Size, Price) VALUES (@Name, @Description, @Category, @Gender, @Color, @Size, @Price)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Color", color);
                cmd.Parameters.AddWithValue("@Size", size);
                cmd.Parameters.AddWithValue("@Price", price);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            BindArticleGrid();
        }

        protected void gvArticles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvArticles.EditIndex = e.NewEditIndex;
            BindArticleGrid();
        }

        protected void gvArticles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int articleId = Convert.ToInt32(gvArticles.DataKeys[e.RowIndex].Value);
            string name = ((TextBox)gvArticles.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string description = ((TextBox)gvArticles.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string category = ((TextBox)gvArticles.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string gender = ((TextBox)gvArticles.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            string color = ((TextBox)gvArticles.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
            string size = ((TextBox)gvArticles.Rows[e.RowIndex].Cells[6].Controls[0]).Text;
            decimal price = decimal.Parse(((TextBox)gvArticles.Rows[e.RowIndex].Cells[7].Controls[0]).Text);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString))
            {
                string query = "UPDATE Articles SET Name = @Name, Description = @Description, Category = @Category, Gender = @Gender, Color = @Color, Size = @Size, Price = @Price WHERE ArticleID = @ArticleID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Color", color);
                cmd.Parameters.AddWithValue("@Size", size);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@ArticleID", articleId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            gvArticles.EditIndex = -1;
            BindArticleGrid();
        }

        protected void gvArticles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int articleId = Convert.ToInt32(gvArticles.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString))
            {
                string query = "DELETE FROM Articles WHERE ArticleID = @ArticleID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ArticleID", articleId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            BindArticleGrid();
        }

    }
}