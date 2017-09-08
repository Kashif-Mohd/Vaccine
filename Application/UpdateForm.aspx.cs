using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Application
{
    public partial class UpdateForm : System.Web.UI.Page
    {
        string connstring = "Data Source=F48604;Initial Catalog=Vaccine; User ID=sa; password=123; Integrated Security=False";
        //string connstring = "Data Source=DESKTOP-8HFQPKA;Initial Catalog=Vaccine; User ID=sa; password=123; Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {           
            TxtDOV.Focus();

            if (Session["User"] != null)
            {
                Label1.Text = Convert.ToString(Session["User"]);
            }
            else
                Response.Redirect("login.aspx");

            if (!Page.IsPostBack)
            {
                this.TextDSSID.Text = Request.QueryString["ID"];
                this.TextCardno.Text = Request.QueryString["Card"];
                PopulateFields();

                string currentDate = DateTime.Today.ToShortDateString();
                CompareDOV.ValueToCompare = currentDate;
                show();
            }            
        }

        public void PopulateFields()
        {            
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            SqlDataReader Reader = null;
            SqlCommand myCommand = new SqlCommand("select * from Form where DSS_ID='" + Request.QueryString["ID"] + "' OR Card_No='" + Request.QueryString["Card"] + "' ", conn);
            Reader = myCommand.ExecuteReader();

            while (Reader.Read())
            {
                TxtDOV.Text = (Reader["Date"].ToString());
                //TextCardno.Text = (Reader["Card_No"].ToString());
                //TextDSSID.Text = (Reader["DSS_ID"].ToString());
                TextName.Text = (Reader["Child_Name"].ToString());
                TextMname.Text = Reader["Mother_Name"].ToString();
                TextFname.Text = (Reader["Father_Name"].ToString());
                TextDOB.Text = (Reader["DOB"].ToString());
                TextCAge.Text = (Reader["Child_Age"].ToString());
                TextMAge.Text = (Reader["Mother_Age"].ToString());
                DropDownList.SelectedValue = (Reader["Gender"].ToString());
                CheckBCG.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["BCG"]));
                CheckOPV0.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["OPV0"]));
                CheckOPV1.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["OPV1"]));
                CheckPenta1.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["Penta1"]));
                CheckPCV1.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["PCV1"]));
                CheckOPV2.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["OPV2"]));
                CheckPenta2.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["Penta2"]));
                CheckPCV2.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["PCV2"]));
                CheckOPV3.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["OPV3"]));
                CheckPenta3.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["Penta3"]));
                CheckPCV3.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["PCV3"]));
                CheckIPV3.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["IPV3"]));
                CheckMeasles1.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["Measles1"]));
                CheckMeasles2.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["Measles2"]));
                CheckTT1.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["TT1"]));
                CheckTT2.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["TT2"]));
                CheckTT3.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["TT3"]));
                CheckTT4.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["TT4"]));
                CheckTT5.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["TT5"]));
                txtremarks.Text = Reader["remarks"].ToString();
            }
            conn.Close();
        }

        public void Update()
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            try
            {
                string UpdateStatement = "BEGIN UPDATE Form SET Date=@Date,Card_No=@Card_No,DSS_ID=@DSS_ID,Child_Name=@Child_Name,Mother_Name=@Mother_Name,Father_Name=@Father_Name,DOB=@DOB, Child_Age=@Child_Age,Mother_Age=@Mother_Age, Gender=@Gender," +
                    "BCG=@BCG,OPV0=@OPV0, OPV1=@OPV1,Penta1=@Penta1,PCV1=@PCV1,OPV2=@OPV2,Penta2=@Penta2,PCV2=@PCV2,OPV3=OPV3,Penta3=Penta3,PCV3=@PCV3,IPV3=@IPV3,Measles1=@Measles1,Measles2=@Measles2,TT1=@TT1,TT2=@TT2,TT3=@TT3,TT4=@TT4,TT5=@TT5,remarks=@remarks,Entry_date=CURRENT_TIMESTAMP,DIO_Name=@DIO_Name where Card_No= '" + TextCardno.Text + "' END";
                //string UpdateStatement = "UPDATE FORM SET Name='"+TextName.Text+"' where DSS_ID= '" + Convert.ToString(Session["DssID"]) + "'";
                SqlCommand cmd = new SqlCommand(UpdateStatement, conn);

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
                Response.Write("<script type=\"text/javascript\">alert('Form Updated successfully!')</script>");
                Server.Transfer("page.aspx");
                //PopulateFields();
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Update();
        }

        public void show()
        {
            if (TextCAge.Text != string.Empty)
            {
                float age = float.Parse(Convert.ToString(TextCAge.Text));
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

        protected void Btnshow_Click(object sender, EventArgs e)
        {
            show(); 
        }
    }
}