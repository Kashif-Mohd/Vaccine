using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace Application
{
    public partial class page : System.Web.UI.Page
    {

        SqlDataReader reader;

        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        //string connstring = "Data Source=F48604;Initial Catalog=Vaccine; User ID=sa; password=123; Integrated Security=False";
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["aabb"] = "1";

            txtdss.Focus();            
            if (Session["User"] != null)
            {
                Label1.Text = Convert.ToString(Session["User"]);
            }
            else
                Response.Redirect("login.aspx");
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }

       
        protected void submitbtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Form where Card_No='" + txtcard.Text + "'", conn);
                reader = cmd.ExecuteReader();

                if (reader.Read()== true)
                {
                    Response.Redirect("UpdateForm.aspx?ID=" + this.txtdss.Text + "&Card=" + this.txtcard.Text);
                }
                else
                {
                    Response.Redirect("Form.aspx?ID=" + this.txtdss.Text + "&Card=" + this.txtcard.Text);
                }
            }
          
            catch (Exception ex)
            {
                showalert(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}