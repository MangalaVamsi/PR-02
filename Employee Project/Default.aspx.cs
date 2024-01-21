using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Employee_PR_01
{
    public partial class _Default : Page
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["database"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                loadgrid();
            }

        }

        private void loadgrid()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionstring);
                sqlConnection.Open();
                string query = "SELECT * FROM dbo.tbl_Employee";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Employees");
                gvHome.DataSource = ds;
                gvHome.DataBind();
                sqlConnection.Dispose();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
        }

        protected void Add_Employee()
        {
            Response.Redirect("AddEmployee.aspx", true);
        }

        protected void gvHome_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int rownum = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = rownum.ToString();

              


            }

        }

        protected void gvHome_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((e.CommandName == "ButtonClick"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvHome.Rows[index];
                int idvalue =Convert.ToInt32( gvHome.Rows[index].Cells[0].Text);
                deleteEmployee(idvalue);





            }
            
        }

        private void deleteEmployee(int v)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionstring);
                sqlConnection.Open();
                string query = "Delete from tbl_Employee  where EmployeeId ="+v;
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Redirect("Default.aspx", true);
            }
            catch (Exception ex)
            {

              Console.WriteLine(ex.Message);
            }
        }


        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee.aspx", true);

        }

      
    }
}