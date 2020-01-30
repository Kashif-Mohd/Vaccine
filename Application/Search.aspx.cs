using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;

namespace Application
{
    public partial class Search : System.Web.UI.Page
    {
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["aabb"] = "2";
            {
                txtdss.Focus();            
                if (Session["User"] != null)
                {
                    Label1.Text = Convert.ToString(Session["User"]);
                }
                else
                    Response.Redirect("login.aspx");
            }
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            ShowData();
        }


        public void ShowData()
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            try
            {
                if (radioList.SelectedValue == "1")
                {
                    GridView1.Visible = true;
                    SqlDataAdapter adpt = new SqlDataAdapter();
                    string query1 = "SELECT a.name as 'Woman Name',b.name as 'Husband Name', a.dss_id_member,a.dob,a.age,a.gender,a.member_type from familydata as a join familydata as b ON b.dss_id_member=a.dss_id_h where a.dss_id_member like '%" + txtdss.Text + "%' and a.name like '%" + txtmname.Text + "%' and b.name like '%" + txthname.Text + "%' ";
                    SqlCommand cmd = new SqlCommand(query1, conn);
                    adpt.SelectCommand = new SqlCommand(query1, conn);
                    System.Data.DataSet ds = new System.Data.DataSet();

                    //SqlDataReader reader = cmd.ExecuteReader();
                    //if (reader.Read() == true)
                    //{
                    //    GridView1.DataSource = reader;
                    //    GridView1.DataBind();
                    //}
                    //else

                    adpt.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = ds;
                        GridView1.DataBind();
                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        GridView1.DataSource = ds;
                        GridView1.DataBind();

                        int columncount = GridView1.Rows[0].Cells.Count;
                        GridView1.Rows[0].Cells.Clear();
                        GridView1.Rows[0].Cells.Add(new TableCell());
                        GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                        GridView1.Rows[0].Cells[0].Text = "No Records Found";
                    }
                    GridView2.Visible = false;
                }
                else if (radioList.SelectedValue == "2")
                {
                    GridView2.Visible = true;
                    SqlDataAdapter adpt = new SqlDataAdapter();
                    string query2 = "SELECT a.name as 'Child Name',b.name as 'Mother Name', c.name as 'Father name', b.dss_id_member,a.dob,a.age,a.gender,a.member_type from  familydata as a join familydata as b ON b.dss_id_member=a.dss_id_m join familydata as c ON c.dss_id_member=a.dss_id_f where a.dss_id_member like '%" + txtdss.Text + "%' and a.name like '%" + txtcname.Text + "%' and b.name like '%" + txtmname.Text + "%' and c.name like '%" + txthname.Text + "%'";
                    SqlCommand cmd = new SqlCommand(query2, conn);
                    adpt.SelectCommand = new SqlCommand(query2, conn);
                    System.Data.DataSet ds = new System.Data.DataSet();

                    //SqlDataReader reader = cmd.ExecuteReader();
                    adpt.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView2.DataSource = ds;
                        GridView2.DataBind();
                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        GridView2.DataSource = ds;
                        GridView2.DataBind();

                        int columncount = GridView1.Rows[0].Cells.Count;
                        GridView2.Rows[0].Cells.Clear();
                        GridView2.Rows[0].Cells.Add(new TableCell());
                        GridView2.Rows[0].Cells[0].ColumnSpan = columncount;
                        GridView2.Rows[0].Cells[0].Text = "No Records Found";
                    }
                    GridView1.Visible = false;
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
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


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    Response.Redirect("Form.aspx?ID=");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }
        
    }
}