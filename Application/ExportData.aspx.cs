using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;

namespace Application
{
    public partial class ExportData : System.Web.UI.Page
    {
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //txtdss.Focus();
            //if (Session["User"] != null)
            //{
            //    Label1.Text = Convert.ToString(Session["User"]);
            //}
            //else
            //    Response.Redirect("login.aspx");
        }

        protected void sbmtbtn_Click(object sender, EventArgs e)
        {
            ShowData();
        }


        public void ShowData()
        {
            string query;
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            try
            {
             
                GridView1.Visible = true;
                SqlDataAdapter adpt = new SqlDataAdapter();
                if (radioList.SelectedValue == "1")
                {
                    query = "select [Date],[Card_No],[DSS_ID],[Mother_Name] as 'Woman Name',[Father_Name] as 'Husband Name',[DOB],[Mother_Age],[TT1],[TT2],[TT3],[TT4],[TT5],[remarks] from Form where Child_Name=''";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    adpt.SelectCommand = new SqlCommand(query, conn);
                }

                else if (radioList.SelectedValue == "2")
                {
                    query = "select [Date],[Card_No],[DSS_ID],[Child_Name],[Mother_Name],[Father_Name],[DOB],[Age_months],[Age_days],[Gender],[BCG],[OPV0],[OPV1],[Penta1],[PCV1],[OPV2],[Penta2],[PCV2],[OPV3],[Penta3],[PCV3],[IPV3],[Measles1],[Measles2],[remarks] from Form where Child_Name!=''";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    adpt.SelectCommand = new SqlCommand(query, conn);
                }

                else
                {
                    query = "select * from Form ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    adpt.SelectCommand = new SqlCommand(query, conn);
                }

                System.Data.DataSet ds = new System.Data.DataSet();

                adpt.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                    Exprtbtn.Visible = true;
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

                    Exprtbtn.Visible = false;
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


        private void Exportdata()
        {
            string query;
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            try
            {
               
                SqlDataAdapter adpt = new SqlDataAdapter();
                if (radioList.SelectedValue == "1")
                {
                    query = "select [Date],[Card_No],[DSS_ID],[Mother_Name] as 'Woman Name',[Father_Name] as 'Husband Name',[DOB],[Mother_Age],[TT1],[TT2],[TT3],[TT4],[TT5],[remarks] from Form where Child_Name=''";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    adpt.SelectCommand = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.Text;
                }

                else if (radioList.SelectedValue == "2")
                {
                    query = "select [Date],[Card_No],[DSS_ID],[Child_Name],[Mother_Name],[Father_Name],[DOB],[Age_months],[Age_days],[Gender],[BCG],[OPV0],[OPV1],[Penta1],[PCV1],[OPV2],[Penta2,[PCV2],[OPV3],[Penta3],[PCV3],[IPV3],[Measles1],[Measles2],[remarks] from Form where Child_Name!=''";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    adpt.SelectCommand = new SqlCommand(query, conn);
                }

                else 
                {
                    query = "select * from Form ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    adpt.SelectCommand = new SqlCommand(query, conn);
                }

                System.Data.DataTable dt = new System.Data.DataTable();

                adpt.Fill(dt);                
                GridView2.DataSource = dt;
                GridView2.DataBind();

               Exprtbtn.Visible = true;
                //else
                //{
                //    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                //    GridView2.DataSource = ds;
                //    GridView2.DataBind();

                //    int columncount = GridView1.Rows[0].Cells.Count;
                //    GridView2.Rows[0].Cells.Clear();
                //    GridView2.Rows[0].Cells.Add(new TableCell());
                //    GridView2.Rows[0].Cells[0].ColumnSpan = columncount;
                //    GridView2.Rows[0].Cells[0].Text = "No Records Found";

                //    Exprtbtn.Visible = false;
                //}

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


        protected void Exprtbtn_Click(object sender, EventArgs e)
        {
            ExcelExport();
        }


        public void ExcelExport()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=VaccineData (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                GridView2.CaptionAlign = TableCaptionAlign.Top;
                
                Exportdata();
                for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
                {
                    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridView2.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridView2.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");

            }
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

    }
}