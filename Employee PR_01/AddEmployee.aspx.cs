using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee_PR_01
{
    public partial class WebForm1 : Page
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["database"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStates();

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string rb = null;
                DateTime columnDate = DateTime.Now;

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
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"INSERT INTO  tbl_Employee (EmployeeName,Designation,Salary,State,Gender,DateOfJoining)");
                stringBuilder.Append(@"VALUES('" + txtName.Text.Trim() + "','" + txtDesignation.Text.Trim() + "', " + txtSalary.Text.Trim() + ",'" + ddlState.Text.Trim() + "', '" + rb + "','" + txtJoiningDate.Text.Trim().ToString() + "')");

                SqlCommand command = new SqlCommand(stringBuilder.ToString(), sqlConnection);
                command.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Redirect("Default.aspx", true);

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


    }
}