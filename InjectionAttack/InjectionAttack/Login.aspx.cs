using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonAddComment_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\Mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True");

        SqlCommand sqlCommand = new SqlCommand("Select * from Employees WHERE FirstName=@name AND LastName=@lastname", sqlConnection);
        sqlCommand.Parameters.AddWithValue("@name", TextBoxUserName.Text);
        sqlCommand.Parameters.AddWithValue("@lastname", TextBoxPass.Text);
        sqlConnection.Open();
        var reader = sqlCommand.ExecuteReader();
        if (reader.Read())
        {
            Session["user"] = reader["FirstName"].ToString();

        }

        sqlConnection.Close();

        if (Session["user"] != null)
        {
            Label1.Text = "Hoş geldiniz...";
        }
        else
        {
            Label1.Text = "Hatalı kullanıcı adı ya da şifre";
            Session["user"] = null;

        }

    }
}