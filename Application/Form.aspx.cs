using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Globalization;

namespace Application
{
    public partial class Form : System.Web.UI.Page
    {
        string currentdate;
        string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        //string connstring = "Data Source=F48604;Initial Catalog=Vaccine; User ID=sa; password=123; Integrated Security=False";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.TextDSSID.Text = Request.QueryString["ID"];
                if (Convert.ToString(Session["aabb"]) == "1")
                {
                    this.TextCardno.Text = Request.QueryString["Card"];
                }
                else if (Convert.ToString(Session["aabb"]) == "2")
                {

                    this.TextName.Text = Request.QueryString["cname"];
                    this.TextMname.Text = Request.QueryString["mname"];
                    this.TextFname.Text = Request.QueryString["hname"];
                }
                TextDSSID.Attributes.Add("readonly", "readonly");
                //AgeMonths.Attributes.Add("readonly", "readonly");
                //AgeDays.Attributes.Add("readonly", "readonly");
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
        }

        //public void show()
        //{
        //    if (TextCAge.Text != string.Empty)
        //    {
        //        float age = float.Parse(TextCAge.Text);
        //        Panel9.Enabled = false;
        //        //MotherPanel.Enabled = false;

        //        if (age >= 1.5 && age < 2.5)
        //        {
        //            //show("week6");
        //            week6.Visible = true;
        //            week10.Visible = false;
        //            week14.Visible = false;
        //            months9.Visible = false;
        //        }
        //        else if (age >= 2.5 && age < 3.5)
        //        {
        //            //show("week6");
        //            //show("week10");
        //            week6.Visible = true;
        //            week10.Visible = true;
        //            week14.Visible = false;
        //            months9.Visible = false;
        //        }
        //        else if (age >= 3.5 && age <= 9)
        //        {
        //            week6.Visible = true;
        //            week10.Visible = true;
        //            week14.Visible = true;
        //            months9.Visible = false;
        //        }
        //        else if (age >= 9 && age <= 15)
        //        {
        //            week6.Visible = true;
        //            week10.Visible = true;
        //            week14.Visible = true;
        //            months9.Visible = true;
        //        }
        //    }

        //    else if (TextMAge.Text != string.Empty)
        //    {
        //        Panel8.Enabled = false;
        //        child.Visible = false;
        //        mother.Visible = true;
        //    }
        //    else
        //    {
        //        //TextCAge.Visible = true;
        //        //TextMAge.Visible = true;
        //        Panel8.Enabled = true;
        //        Panel9.Enabled = true;
        //        child.Visible = true;
        //        mother.Visible = false;
        //    }
        //}










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
                    IDCheck();
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


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }


        public void DataSubmit()
        {
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                conn.Open();

                string insertStatement = "BEGIN INSERT INTO Form(Date,Card_No,DSS_ID,Child_Name,Mother_Name,Father_Name,DOB, Age_months,Age_days,Mother_Age,Gender, BCG,OPV0, OPV1,Penta1,PCV1,OPV2,Penta2,PCV2,OPV3,Penta3,PCV3,IPV3,Measles1,Measles2,TT1,TT2,TT3,TT4,TT5,remarks,Entry_date,DIO_Name,date_1,date_2,date_3,date_4,date_5,date_6,date_7,date_m1,date_m2,date_m3,date_m4,date_m5,QR_Code,Rota1,Rota2,TCV)" +
                     "VALUES (@Date, @Card_No,@DSS_ID,@Child_Name,@Mother_Name,@Father_Name,@DOB,@Age_months,@Age_days,@Mother_Age,@Gender,@BCG,@OPV0,@OPV1,@Penta1,@PCV1,@OPV2,@Penta2,@PCV2,@OPV3,@Penta3,@PCV3,@IPV3,@Measles1,@Measles2,@TT1,@TT2,@TT3,@TT4,@TT5,@remarks,CURRENT_TIMESTAMP,@DIO_Name,@DateV1,@DateV2,@DateV3,@DateV4,@DateV5,@DateV6,@DateV7,@DateMV1,@DateMV2,@DateMV3,@DateMV4,@DateMV5,@QRcode,@Rota1,@Rota2,@TCV) END";

                SqlCommand cmd = new SqlCommand(insertStatement, conn);

                cmd.Parameters.AddWithValue("@Date", TxtDOV.Text);
                cmd.Parameters.AddWithValue("@Card_No", TextCardno.Text);
                cmd.Parameters.AddWithValue("@DSS_ID", TextDSSID.Text.ToUpper());
                cmd.Parameters.AddWithValue("@Child_Name", TextName.Text.ToUpper());
                cmd.Parameters.AddWithValue("@Mother_Name", TextMname.Text.ToUpper());
                cmd.Parameters.AddWithValue("@Father_Name", TextFname.Text.ToUpper());
                cmd.Parameters.AddWithValue("@DOB", TextDOB.Text);
                cmd.Parameters.AddWithValue("@Age_months", AgeMonths.Text);
                cmd.Parameters.AddWithValue("@Age_days", AgeDays.Text);
                cmd.Parameters.AddWithValue("@Mother_Age", TextMAge.Text);
                cmd.Parameters.AddWithValue("@Gender", radioList.SelectedValue);
                cmd.Parameters.AddWithValue("@BCG", (CheckBCG.Checked));
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
                cmd.Parameters.AddWithValue("@Measles1", CheckMeasles1.Checked);
                cmd.Parameters.AddWithValue("@Measles2", CheckMeasles2.Checked);
                cmd.Parameters.AddWithValue("@TCV", CheckTCV.Checked);
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
                conn.Close();
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
            SqlCommand cmd = new SqlCommand("Select * from Form where Card_No='" + TextCardno.Text + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This ID Already Entered')", true);
            }

            else
            {
                DataSubmit();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Form Saved Successfully!');window.location.href='page.aspx';", true);

                //Response.Write("<script type=\"text/javascript\">alert('Form Submitted successfully!')</script>");
                ////Response.Redirect("Form.aspx");
                //Server.Transfer("page.aspx");
            }
            con.Close();
        }




        //Group 1:

        //protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        //{           
        //    if (CheckBCG.Checked)
        //    {
        //        txtDateV1.ReadOnly = false;
        //        txtDateV1.Focus();
        //        //txtDateV1.Attributes.Add("readonly", "readonly");
        //    }
        //    else
        //    {
        //        if (!CheckOPV0.Checked)
        //        {
        //            txtDateV1.ReadOnly = true;
        //            txtDateV1.Text = "";
        //            txtDateV1.Focus();
        //        }
        //    }
        //    mother.Visible = false;
        //}



    }
}