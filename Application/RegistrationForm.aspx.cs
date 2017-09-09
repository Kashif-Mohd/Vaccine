using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Application
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        //string connstring = "Data Source=F48604;Initial Catalog=Vaccine; User ID=sa; password=123; Integrated Security=False";
        //string connstring = "Data Source=DESKTOP-8HFQPKA;Initial Catalog=Vaccine; User ID=sa; password=123; Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }                
        }

        public bool IDCheck()
        {
            SqlConnection con = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("Select * from UserRegistration where username = '" + Textuname.Text + "' ", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            finally { con.Close(); }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            IDCheck();
            if (IDCheck())
            {
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                try
                {
                    string insertStatement = "INSERT INTO UserRegistration(username, email, password)" +
                         "VALUES (@username, @email, @password)";
                    SqlCommand cmd = new SqlCommand(insertStatement, conn);
                    cmd.Parameters.AddWithValue("@username", Textuname.Text);
                    cmd.Parameters.AddWithValue("@email", Textemail.Text);
                    cmd.Parameters.AddWithValue("@password", Textpass.Text);
                    cmd.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    string msg = "Insert Error:";
                    msg += ex.Message;
                    throw new Exception(msg);
                }
                finally
                {
                    conn.Close();
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User created successfully!');window.location ='page.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This user ID Already Exist');window.location ='RegistrationForm.aspx';", true);
            }
        }
    }
}