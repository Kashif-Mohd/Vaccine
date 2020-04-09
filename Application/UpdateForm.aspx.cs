using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;

namespace Application
{
    public partial class UpdateForm : System.Web.UI.Page
    {
        string currentdate;
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        //string connstring = "Data Source=F48604;Initial Catalog=Vaccine; User ID=sa; password=123; Integrated Security=False";
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtDOV.Focus();
            TextCardno.Attributes.Add("readonly", "readonly");
            AgeMonths.Attributes.Add("readonly", "readonly");
            AgeDays.Attributes.Add("readonly", "readonly");

            if (Session["User"] != null)
            {
                Label1.Text = Convert.ToString(Session["User"]);
            }
            else
                Response.Redirect("login.aspx");

            if (!Page.IsPostBack)
            {
                //this.TextDSSID.Text = Request.QueryString["ID"];
                this.TextCardno.Text = Request.QueryString["Card"];
                PopulateFields();
                //if (txtDateMV1.Text == "" && txtDateMV2.Text == "" && txtDateMV3.Text == "" && txtDateMV4.Text == "" && txtDateMV5.Text == "")
                //{
                //    mother.Visible = false;
                //}
                //else{
                //    child.Visible = false;
                //}

                string currentDate = DateTime.Today.ToShortDateString();
                CompareDOV.ValueToCompare = currentDate;
            }
        }

        public void PopulateFields()
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            SqlDataReader Reader = null;
            SqlCommand myCommand = new SqlCommand("select * from Form where Card_No='" + Request.QueryString["Card"] + "' ", conn);
            Reader = myCommand.ExecuteReader();

            while (Reader.Read())
            {
                TxtDOV.Text = (Reader["Date"].ToString());
                //TextCardno.Text = (Reader["Card_No"].ToString());
                TextDSSID.Text = (Reader["DSS_ID"].ToString());
                TextName.Text = (Reader["Child_Name"].ToString());
                TextMname.Text = Reader["Mother_Name"].ToString();
                TextFname.Text = (Reader["Father_Name"].ToString());
                TextDOB.Text = (Reader["DOB"].ToString());
                AgeMonths.Text = (Reader["Age_months"].ToString());
                AgeDays.Text = (Reader["Age_days"].ToString());
                TextMAge.Text = (Reader["Mother_Age"].ToString());
                radioList.SelectedValue = (Reader["Gender"].ToString());
                CheckBCG.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["BCG"]));
                CheckOPV0.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["OPV0"]));

                CheckOPV1.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["OPV1"]));
                CheckPenta1.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["Penta1"]));
                CheckPCV1.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["PCV1"]));
                CheckRota1.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["Rota1"]));
                
                CheckOPV2.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["OPV2"]));
                CheckPenta2.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["Penta2"]));
                CheckPCV2.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["PCV2"]));
                CheckRota2.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["Rota2"]));

                CheckOPV3.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["OPV3"]));
                CheckPenta3.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["Penta3"]));
                CheckPCV3.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["PCV3"]));
                CheckIPV3.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["IPV3"]));

                CheckMeasles1.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["Measles1"]));
                CheckTCV.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["TCV"]));
                
                CheckMeasles2.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["Measles2"]));
                
                
                CheckTT1.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["TT1"]));
                CheckTT2.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["TT2"]));
                CheckTT3.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["TT3"]));
                CheckTT4.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["TT4"]));
                CheckTT5.Checked = Convert.ToBoolean(Convert.ToInt32(Reader["TT5"]));
                txtremarks.InnerText = Reader["remarks"].ToString();

                txtQRcode.Text = (Reader["QR_Code"].ToString());
                txtDateV1.Text = (Reader["date_1"].ToString());
                txtDateV2.Text = (Reader["date_2"].ToString());
                txtDateV3.Text = (Reader["date_3"].ToString());
                txtDateV4.Text = (Reader["date_4"].ToString());
                txtDateV5.Text = (Reader["date_5"].ToString());
                txtDateV6.Text = (Reader["date_6"].ToString());
                txtDateV7.Text = (Reader["date_7"].ToString());

                txtDateMV1.Text = (Reader["date_m1"].ToString());
                txtDateMV2.Text = (Reader["date_m2"].ToString());
                txtDateMV3.Text = (Reader["date_m3"].ToString());
                txtDateMV4.Text = (Reader["date_m4"].ToString());
                txtDateMV5.Text = (Reader["date_m5"].ToString());
            }
            conn.Close();
        }

        public void Update()
        {
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            try
            {
                string UpdateStatement = "BEGIN UPDATE Form SET Date=@Date,DSS_ID=@DSS_ID,Child_Name=@Child_Name,Mother_Name=@Mother_Name,Father_Name=@Father_Name,DOB=@DOB, Age_months=@Age_months, Age_days=@Age_days, Mother_Age=@Mother_Age, Gender=@Gender," +
                    "BCG=@BCG,OPV0=@OPV0, OPV1=@OPV1,Penta1=@Penta1,PCV1=@PCV1,Rota1=@Rota1,OPV2=@OPV2,Penta2=@Penta2,PCV2=@PCV2,Rota2=@Rota2,OPV3=@OPV3,Penta3=@Penta3,PCV3=@PCV3,IPV3=@IPV3,Measles1=@Measles1,TCV=@TCV,Measles2=@Measles2,TT1=@TT1,TT2=@TT2,TT3=@TT3,TT4=@TT4,TT5=@TT5,remarks=@remarks,update_date=CURRENT_TIMESTAMP,update_name=@DIO_Name,date_1=@DateV1,date_2=@DateV2,date_3=@DateV3,date_4=@DateV4,date_5=@DateV5,date_6=@DateV6,date_7=@DateV7,date_m1=@DateMV1,date_m2=@DateMV2,date_m3=@DateMV3,date_m4=@DateMV4,date_m5=@DateMV5,QR_Code=@QRcode where Card_No= '" + TextCardno.Text + "' END";
                //string UpdateStatement = "UPDATE FORM SET Name='"+TextName.Text+"' where DSS_ID= '" + Convert.ToString(Session["DssID"]) + "'";
                SqlCommand cmd = new SqlCommand(UpdateStatement, conn);

                cmd.Parameters.AddWithValue("@Date", TxtDOV.Text);
                //cmd.Parameters.AddWithValue("@Card_No", TextCardno.Text);
                cmd.Parameters.AddWithValue("@DSS_ID", TextDSSID.Text.ToUpper());
                cmd.Parameters.AddWithValue("@Child_Name", TextName.Text.ToUpper());
                cmd.Parameters.AddWithValue("@Mother_Name", TextMname.Text.ToUpper());
                cmd.Parameters.AddWithValue("@Father_Name", TextFname.Text.ToUpper());
                cmd.Parameters.AddWithValue("@DOB", TextDOB.Text);
                cmd.Parameters.AddWithValue("@Age_months", AgeMonths.Text);
                cmd.Parameters.AddWithValue("@Age_days", AgeDays.Text);
                cmd.Parameters.AddWithValue("@Mother_Age", TextMAge.Text);
                cmd.Parameters.AddWithValue("@Gender", radioList.SelectedValue);
                cmd.Parameters.AddWithValue("@BCG", CheckBCG.Checked);
                cmd.Parameters.AddWithValue("@OPV0", CheckOPV0.Checked);
                cmd.Parameters.AddWithValue("@OPV1", CheckOPV1.Checked);
                cmd.Parameters.AddWithValue("@Penta1", CheckPenta1.Checked);
                cmd.Parameters.AddWithValue("@PCV1", CheckPCV1.Checked);
                cmd.Parameters.AddWithValue("@Rota1", CheckRota1.Checked);
                cmd.Parameters.AddWithValue("@OPV2", CheckOPV2.Checked);
                cmd.Parameters.AddWithValue("@Penta2", CheckPenta2.Checked);
                cmd.Parameters.AddWithValue("@PCV2", CheckPCV2.Checked);
                cmd.Parameters.AddWithValue("@Rota2", CheckRota2.Checked);
                cmd.Parameters.AddWithValue("@OPV3", CheckOPV3.Checked);
                cmd.Parameters.AddWithValue("@Penta3", CheckPenta3.Checked);
                cmd.Parameters.AddWithValue("@PCV3", CheckPCV3.Checked);
                cmd.Parameters.AddWithValue("@IPV3", CheckIPV3.Checked);
                cmd.Parameters.AddWithValue("@TCV", CheckTCV.Checked);
                cmd.Parameters.AddWithValue("@Measles1", CheckMeasles1.Checked);
                cmd.Parameters.AddWithValue("@Measles2", CheckMeasles2.Checked);
                cmd.Parameters.AddWithValue("@TT1", CheckTT1.Checked);
                cmd.Parameters.AddWithValue("@TT2", CheckTT2.Checked);
                cmd.Parameters.AddWithValue("@TT3", CheckTT3.Checked);
                cmd.Parameters.AddWithValue("@TT4", CheckTT4.Checked);
                cmd.Parameters.AddWithValue("@TT5", CheckTT5.Checked);
                cmd.Parameters.AddWithValue("@remarks", txtremarks.InnerText.ToUpper());
                cmd.Parameters.AddWithValue("@DIO_Name", Label1.Text.ToUpper());
                cmd.Parameters.AddWithValue("@DateV1", txtDateV1.Text);
                cmd.Parameters.AddWithValue("@DateV2", txtDateV2.Text);
                cmd.Parameters.AddWithValue("@DateV3", txtDateV3.Text);
                cmd.Parameters.AddWithValue("@DateV4", txtDateV4.Text);
                cmd.Parameters.AddWithValue("@DateV5", txtDateV5.Text);
                cmd.Parameters.AddWithValue("@DateV6", txtDateV6.Text);
                cmd.Parameters.AddWithValue("@DateV7", txtDateV7.Text);
                cmd.Parameters.AddWithValue("@DateMV1", txtDateMV1.Text);
                cmd.Parameters.AddWithValue("@DateMV2", txtDateMV2.Text);
                cmd.Parameters.AddWithValue("@DateMV3", txtDateMV3.Text);
                cmd.Parameters.AddWithValue("@DateMV4", txtDateMV4.Text);
                cmd.Parameters.AddWithValue("@DateMV5", txtDateMV5.Text);
                cmd.Parameters.AddWithValue("@QRcode", txtQRcode.Text);
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
        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            currentdate = DateTime.Now.ToString("dd/MM/yyyy");
            try
            {
                if (TextName.Text != "" && (TextDOB.Text == "" || TextDOB.Text == "__/__/____"))
                {
                    showalert("Enter Date of Birth");
                    TextDOB.Focus();
                }
                else if (TextName.Text != "" && (!CheckBCG.Checked && !CheckOPV0.Checked && !CheckOPV1.Checked && !CheckPenta1.Checked && !CheckPCV1.Checked && !CheckRota1.Checked && !CheckOPV2.Checked && !CheckPenta2.Checked && !CheckPCV2.Checked && !CheckRota2.Checked && !CheckOPV3.Checked && !CheckPenta3.Checked && !CheckPCV3.Checked && !CheckIPV3.Checked && !CheckMeasles1.Checked && !CheckMeasles2.Checked && !CheckTCV.Checked))
                {
                    showalert("Please select Child Vaccine");
                    CheckBCG.Focus();
                }
                else if (TextName.Text == "" && (!CheckTT1.Checked && !CheckTT2.Checked && !CheckTT3.Checked && !CheckTT4.Checked && !CheckTT5.Checked))
                {
                    showalert("Please select Woman Vaccine");
                    CheckTT1.Focus();
                }
                else if ((txtDateV1.Text == "" || txtDateV1.Text == "__/__/____") && (CheckBCG.Checked || CheckOPV0.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateV1.Focus();
                }
                else if ((txtDateV2.Text == "" || txtDateV2.Text == "__/__/____") && (CheckOPV1.Checked || CheckPenta1.Checked || CheckPCV1.Checked || CheckRota1.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateV2.Focus();
                }
                else if ((txtDateV3.Text == "" || txtDateV3.Text == "__/__/____") && (CheckOPV2.Checked || CheckPenta2.Checked || CheckPCV2.Checked || CheckRota2.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateV3.Focus();
                }
                else if ((txtDateV4.Text == "" || txtDateV4.Text == "__/__/____") && (CheckOPV3.Checked || CheckPenta3.Checked || CheckPCV3.Checked || CheckIPV3.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateV4.Focus();
                }
                else if ((txtDateV5.Text == "" || txtDateV5.Text == "__/__/____") && (CheckMeasles1.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateV5.Focus();
                }
                else if ((txtDateV6.Text == "" || txtDateV6.Text == "__/__/____") && (CheckMeasles2.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateV6.Focus();
                }
                else if ((txtDateV7.Text == "" || txtDateV7.Text == "__/__/____") && (CheckTCV.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateV7.Focus();
                }

                else if ((txtDateMV1.Text == "" || txtDateMV1.Text == "__/__/____") && (CheckTT1.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateMV1.Focus();
                }
                else if ((txtDateMV2.Text == "" || txtDateMV2.Text == "__/__/____") && (CheckTT2.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateMV2.Focus();
                }
                else if ((txtDateMV3.Text == "" || txtDateMV3.Text == "__/__/____") && (CheckTT3.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateMV3.Focus();
                }
                else if ((txtDateMV4.Text == "" || txtDateMV4.Text == "__/__/____") && (CheckTT4.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateMV4.Focus();
                }
                else if ((txtDateMV5.Text == "" || txtDateMV5.Text == "__/__/____") && (CheckTT5.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateMV5.Focus();
                }
                else if ((txtDateMV1.Text == "" || txtDateMV1.Text == "__/__/____") && (CheckTT1.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateMV1.Focus();
                }
                else if ((txtDateMV2.Text == "" || txtDateMV2.Text == "__/__/____") && (CheckTT2.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateMV2.Focus();
                }
                else if ((txtDateMV3.Text == "" || txtDateMV3.Text == "__/__/____") && (CheckTT3.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateMV3.Focus();
                }
                else if ((txtDateMV4.Text == "" || txtDateMV4.Text == "__/__/____") && (CheckTT4.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateMV4.Focus();
                }
                else if ((txtDateMV5.Text == "" || txtDateMV5.Text == "__/__/____") && (CheckTT5.Checked))
                {
                    showalert("Enter Date of Visit");
                    txtDateMV5.Focus();
                }


                    //Date Child Current Checks:
                else if (txtDateV1.Text != "99/99/9999" && txtDateV1.Text != "" && ((TextDOB.Text != "" && (DateTime.ParseExact(txtDateV1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(TextDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)) || DateTime.ParseExact(txtDateV1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))))
                {
                    showalert("Enter Less than Current Date & Greater than Date of Birth!");
                    txtDateV1.Focus();
                }
                else if (txtDateV2.Text != "99/99/9999" && txtDateV2.Text != "" && ((TextDOB.Text != "" && (DateTime.ParseExact(txtDateV2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(TextDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)) || DateTime.ParseExact(txtDateV2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))))
                {
                    showalert("Enter Less than Current Date & Greater than Date of Birth!");
                    txtDateV2.Focus();
                }
                else if (txtDateV3.Text != "99/99/9999" && txtDateV3.Text != "" && ((TextDOB.Text != "" && (DateTime.ParseExact(txtDateV3.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(TextDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)) || DateTime.ParseExact(txtDateV3.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))))
                {
                    showalert("Enter Less than Current Date & Greater than Date of Birth!");
                    txtDateV3.Focus();
                }
                else if (txtDateV4.Text != "99/99/9999" && txtDateV4.Text != "" && ((TextDOB.Text != "" && (DateTime.ParseExact(txtDateV4.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(TextDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)) || DateTime.ParseExact(txtDateV4.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))))
                {
                    showalert("Enter Less than Current Date & Greater than Date of Birth!");
                    txtDateV4.Focus();
                }
                else if (txtDateV5.Text != "99/99/9999" && txtDateV5.Text != "" && ((TextDOB.Text != "" && (DateTime.ParseExact(txtDateV5.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(TextDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)) || DateTime.ParseExact(txtDateV5.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))))
                {
                    showalert("Enter Less than Current Date & Greater than Date of Birth!");
                    txtDateV5.Focus();
                }
                else if (txtDateV6.Text != "99/99/9999" && txtDateV6.Text != "" && ((TextDOB.Text != "" && (DateTime.ParseExact(txtDateV6.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(TextDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)) || DateTime.ParseExact(txtDateV6.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))))
                {
                    showalert("Enter Less than Current Date & Greater than Date of Birth!");
                    txtDateV6.Focus();
                }
                else if (txtDateV7.Text != "99/99/9999" && txtDateV7.Text != "" && ((TextDOB.Text != "" && (DateTime.ParseExact(txtDateV7.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(TextDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)) || DateTime.ParseExact(txtDateV7.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))))
                {
                    showalert("Enter Less than Current Date & Greater than Date of Birth!");
                    txtDateV7.Focus();
                }



                   //Date Mother Current Checks:
                else if (txtDateMV1.Text != "99/99/9999" && txtDateMV1.Text != "" && (DateTime.ParseExact(txtDateMV1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd/MM/yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, enter Less than Current Date!");
                    txtDateMV1.Focus();
                }
                else if (txtDateMV2.Text != "99/99/9999" && txtDateMV2.Text != "" && (DateTime.ParseExact(txtDateMV2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd/MM/yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, enter Less than Current Date!");
                    txtDateMV2.Focus();
                }
                else if (txtDateMV3.Text != "99/99/9999" && txtDateMV3.Text != "" && (DateTime.ParseExact(txtDateMV3.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd/MM/yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, enter Less than Current Date!");
                    txtDateMV3.Focus();
                }
                else if (txtDateMV4.Text != "99/99/9999" && txtDateMV4.Text != "" && (DateTime.ParseExact(txtDateMV4.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd/MM/yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, enter Less than Current Date!");
                    txtDateMV4.Focus();
                }
                else if (txtDateMV5.Text != "99/99/9999" && txtDateMV5.Text != "" && (DateTime.ParseExact(txtDateMV5.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd/MM/yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, enter Less than Current Date!");
                    txtDateMV5.Focus();
                }

                else
                {
                    Update();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The DateTime represented by the string is not supported in calendar System.Globalization.GregorianCalendar.")
                {
                    showalert("Incorrect Date Format!");
                }
                else
                {
                    showalert(ex.Message);
                }
            }
        }



    }
}