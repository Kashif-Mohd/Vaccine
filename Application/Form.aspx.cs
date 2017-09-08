using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace Application
{
    public partial class Form : System.Web.UI.Page
    {
        string connstring = "Data Source=F48604;Initial Catalog=Vaccine; User ID=sa; password=123; Integrated Security=False";
        //string connstring = "Data Source=DESKTOP-8HFQPKA;Initial Catalog=Vaccine; User ID=sa; password=123; Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TextDSSID.Text = Request.QueryString["ID"];
            this.TextCardno.Text = Request.QueryString["Card"];

            TextDSSID.Attributes.Add("readonly", "readonly");
            TextCardno.Attributes.Add("readonly", "readonly");
            TextCAge.Attributes.Add("readonly", "readonly");
            TxtDOV.Focus();

            if (Session["User"] != null)
            {
                Label1.Text = Convert.ToString(Session["User"]).ToUpper();
            }
            else
                Response.Redirect("login.aspx");


            if (!Page.IsPostBack)
            {
                string currentDate = DateTime.Today.ToShortDateString();
                CompareDOV.ValueToCompare = currentDate;
                //show();
            }
        }

        public void show()
        {
            if (TextCAge.Text != string.Empty)
            {
                float age = float.Parse(TextCAge.Text);
                Panel9.Enabled = false;
                //MotherPanel.Enabled = false;

                if (age >= 1.5 && age < 2.5)
                {
                    //show("week6");
                    week6.Visible = true;
                    week10.Visible = false;
                    week14.Visible = false;
                    months9.Visible = false;
                }
                else if (age >= 2.5 && age < 3.5)
                {
                    //show("week6");
                    //show("week10");
                    week6.Visible = true;
                    week10.Visible = true;
                    week14.Visible = false;
                    months9.Visible = false;
                }
                else if (age >= 3.5 && age <= 9)
                {
                    week6.Visible = true;
                    week10.Visible = true;
                    week14.Visible = true;
                    months9.Visible = false;
                }
                else if (age >= 9 && age <= 15)
                {
                    week6.Visible = true;
                    week10.Visible = true;
                    week14.Visible = true;
                    months9.Visible = true;
                }
            }

            else if (TextMAge.Text != string.Empty)
            {
                Panel8.Enabled = false;
                child.Visible = false;
                mother.Visible = true;
            }
            else
            {
                //TextCAge.Visible = true;
                //TextMAge.Visible = true;
                Panel8.Enabled = true;
                Panel9.Enabled = true;
                child.Visible = true;
                mother.Visible = false;
            }
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            IDCheck();           
        }

        public void DataSubmit()
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            try
            {
                string insertStatement = "IF NOT EXISTS(SELECT * FROM Form WHERE DSS_ID = '" + TextDSSID.Text + "')" +
                    "BEGIN INSERT INTO Form(Date,Card_No,DSS_ID,Child_Name,Mother_Name,Father_Name,DOB, Child_Age,Mother_Age,Gender, BCG,OPV0, OPV1,Penta1,PCV1,OPV2,Penta2,PCV2,OPV3,Penta3,PCV3,IPV3,Measles1,Measles2,TT1,TT2,TT3,TT4,TT5,Entry_date,DIO_Name)" +
                     "VALUES (@Date, @Card_No,@DSS_ID,@Child_Name,@Mother_Name,@Father_Name,@DOB,@Child_Age,@Mother_Age,@Gender,@BCG,@OPV0,@OPV1,@Penta1,@PCV1,@OPV2,@Penta2,@PCV2,@OPV3,@Penta3,@PCV3,@IPV3,@Measles1,@Measles2,@TT1,@TT2,@TT3,@TT4,@TT5,CURRENT_TIMESTAMP,@DIO_Name) END";

                SqlCommand cmd = new SqlCommand(insertStatement, conn);

                cmd.Parameters.AddWithValue("@Date", TxtDOV.Text);
                cmd.Parameters.AddWithValue("@Card_No", TextCardno.Text);
                cmd.Parameters.AddWithValue("@DSS_ID", TextDSSID.Text.ToUpper());
                cmd.Parameters.AddWithValue("@Child_Name", TextName.Text.ToUpper());
                cmd.Parameters.AddWithValue("@Mother_Name", TextMname.Text.ToUpper());
                cmd.Parameters.AddWithValue("@Father_Name", TextFname.Text.ToUpper());
                cmd.Parameters.AddWithValue("@DOB", TextDOB.Text);
                cmd.Parameters.AddWithValue("@Child_Age", TextCAge.Text);
                cmd.Parameters.AddWithValue("@Mother_Age", TextMAge.Text);
                cmd.Parameters.AddWithValue("@Gender", DropDownList.Text);
                cmd.Parameters.AddWithValue("@BCG", CheckBCG.Checked);
                cmd.Parameters.AddWithValue("@OPV0", CheckOPV0.Checked);
                cmd.Parameters.AddWithValue("@OPV1", CheckOPV1.Checked);
                cmd.Parameters.AddWithValue("@Penta1", CheckPenta1.Checked);
                cmd.Parameters.AddWithValue("@PCV1", CheckPCV1.Checked);
                cmd.Parameters.AddWithValue("@OPV2", CheckOPV2.Checked);
                cmd.Parameters.AddWithValue("@Penta2", CheckPenta2.Checked);
                cmd.Parameters.AddWithValue("@PCV2", CheckPCV2.Checked);
                cmd.Parameters.AddWithValue("@OPV3", CheckOPV3.Checked);
                cmd.Parameters.AddWithValue("@Penta3", CheckPenta3.Checked);
                cmd.Parameters.AddWithValue("@PCV3", CheckPCV3.Checked);
                cmd.Parameters.AddWithValue("@IPV3", CheckIPV3.Checked);
                cmd.Parameters.AddWithValue("@Measles1", CheckMeasles1.Checked);
                cmd.Parameters.AddWithValue("@Measles2", CheckMeasles2.Checked);
                cmd.Parameters.AddWithValue("@TT1", CheckTT1.Checked);
                cmd.Parameters.AddWithValue("@TT2", CheckTT2.Checked);
                cmd.Parameters.AddWithValue("@TT3", CheckTT3.Checked);
                cmd.Parameters.AddWithValue("@TT4", CheckTT4.Checked);
                cmd.Parameters.AddWithValue("@TT5", CheckTT5.Checked);
                cmd.Parameters.AddWithValue("@remarks", txtremarks.Text);
                cmd.Parameters.AddWithValue("@DIO_Name", Label1.Text.ToUpper());
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Btnshow_Click(object sender, EventArgs e)
        {
            //show();
            //week6.Style["display"] = "none";                           
        }

        public void IDCheck()
        {
            SqlConnection con = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("Select * from Form where DSS_ID='" + TextDSSID.Text + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This ID Already Exist')", true);
            }
            else
            {
                DataSubmit();
                Response.Write("<script type=\"text/javascript\">alert('Form Submitted successfully!')</script>");
                //Response.Redirect("Form.aspx");
                Server.Transfer("page.aspx");
            }
        }
        
    }
}