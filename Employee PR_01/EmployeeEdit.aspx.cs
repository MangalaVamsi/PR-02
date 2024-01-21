using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;



namespace Employee_PR_01
{
    public partial class EmployeeEdit : Page
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["database"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack && Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);

                    LoadData(id);
                    BindStates();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }

        private void BindStates()
        {
            List<string> states = GetIndiaStates();

            ddlState.DataSource = states;
            ddlState.DataBind();
        }

        private void LoadData(int id)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionstring);
                sqlConnection.Open();
                string query = "SELECT * FROM dbo.tbl_Employee WHERE EmployeeId = " + id;
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                bindValuesToFeild(dt,id);
                sqlConnection.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void bindValuesToFeild(DataTable dt ,int id)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtName.Text = row["EmployeeName"].ToString();
                    txtDesignation.Text= row["Designation"].ToString();
                    txtSalary.Text= row["Salary"].ToString();
                   // txtState.Text = row["State"].ToString();
                    ddlState.Text = row["State"].ToString();
                    txtSalary.Text = row["Salary"].ToString();
                    if (row["Gender"].ToString() == "Male")
                    {
                        rbMale.Checked=true;
                    }
                    else
                    {
                        rbFemale.Checked=true;

                    }
                    txtJoiningDate.Text = DateTime.Parse(row["DateOfJoining"].ToString()).ToString("yyyy-mm-dd");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        private List<string> GetIndiaStates()
        {
            List<string> indiaStates = new List<string>
        {
            "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh",
            "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jharkhand", "Karnataka",
            "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram",
            "Nagaland", "Odisha", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana",
            "Tripura", "Uttar Pradesh", "Uttarakhand", "West Bengal"
        };
            return indiaStates;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string rb = null;

                if (rbMale.Checked == true)
                {
                    rb = rbMale.Text.ToString();
                }
                else if (rbFemale.Checked == true)
                {
                    rb = rbFemale.Text.ToString();
                }
                SqlConnection sqlConnection = new SqlConnection(connectionstring);
                sqlConnection.Open();
                string query = "UPDATE tbl_Employee set EmployeeName = '" + txtName.Text.Trim() + "' ,Designation = '" + txtDesignation.Text.Trim() + "' ,Salary = " + txtSalary.Text.Trim() + ",State = '" + ddlState.Text.Trim() + "',Gender = '" + rb + "',DateOfJoining = '" + txtJoiningDate.Text.Trim().ToString() + "' where EmployeeId = " + Convert.ToInt32(Request.QueryString["id"]);
                SqlCommand command = new SqlCommand(query, sqlConnection);  
                command.ExecuteNonQuery();
                sqlConnection.Close();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                
                Response.Redirect("Default.aspx", true);

            }
            catch (Exception ex)
            {

               Console.WriteLine (ex.Message);  
            }
           

        }
    }
}