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
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        //string connstring = "Data Source=F48604;Initial Catalog=Vaccine; User ID=sa; password=123; Integrated Security=False";
        protected void Page_Load(object sender, EventArgs e)
        {
            txtdss.Focus();
            Session["DssID"] = null;
            Session["card"] = null;
            if (Session["User"] != null)
            {
                Label1.Text = Convert.ToString(Session["User"]);
            }
            else
                Response.Redirect("login.aspx");
        }

        public void showPopUp(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            try
            {
                SqlDataAdapter adpt = new SqlDataAdapter();
                string SelectStatement = "Select * from Form where Card_No='" + txtcard.Text + "' ";
                SqlCommand cmd = new SqlCommand(SelectStatement, conn);
                adpt.SelectCommand = new SqlCommand(SelectStatement, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.HasRows == true)
                {
                    //GridView1.DataSource = reader;
                    //GridView1.DataBind();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This ID already exists.')", true);
                    Response.Redirect("UpdateForm.aspx?ID=" + this.txtdss.Text + "&Card=" + this.txtcard.Text);
                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No records found.')", true);
                    Response.Redirect("Form.aspx?ID=" + this.txtdss.Text + "&Card=" + this.txtcard.Text);
                }                
            }
            catch (System.Threading.ThreadAbortException) {
            }
            catch (SystemException ex)
            {
                string msg = "";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
        //        e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
        //        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
        //        e.Row.ToolTip = "Click to select this row.";
        //    }
        //}

        //protected void OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    foreach (GridViewRow row in GridView1.Rows)
        //    {
        //        if (row.RowIndex == GridView1.SelectedIndex)
        //        {
        //            row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
        //            row.ToolTip = string.Empty;
        //            Session["DssID"] = txtsearch.Text;
        //            Session["card"] = txtsearch.Text;
        //            Response.Redirect("UpdateForm.aspx");                   
        //        }
        //        else
        //        {
        //            row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
        //            row.ToolTip = "Click to select this row.";
        //        }
        //    }
        //}
    }
}