using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connStr = "Data Source=SAUMITA; Initial Catalog=Employee; User Id=sa; Password=sa@123; Trusted_Connection=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindDepartment(ddlDepartment);
                BindGrid();
            }
        }

        protected void gvEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                RadioButtonList rblGender = (RadioButtonList)e.Row.FindControl("rblGender");
                if (rblGender != null)
                {
                    string genderId = gvEmployee.DataKeys[e.Row.RowIndex]["GenderId"].ToString();
                    rblGender.SelectedValue = genderId;
                }

                DropDownList ddlDept = (DropDownList)e.Row.FindControl("ddlDept");
                if (ddlDept != null)
                {
                    BindDepartment(ddlDept);

                    string deptId = gvEmployee.DataKeys[e.Row.RowIndex]["DeptId"].ToString();
                    ddlDept.SelectedValue = deptId;
                }
            }

        }

        protected void gvEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmployee.EditIndex = -1;
            BindGrid();
        }

        protected void gvEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvEmployee.Rows[e.RowIndex];
            string Id = row.Cells[0].Text;
            TextBox txt_name = (TextBox)row.Cells[1].Controls[0];
            string Name = txt_name.Text;
            RadioButtonList rblGender = (RadioButtonList)row.FindControl("rblGender");
            int Gender = Convert.ToInt32(rblGender.SelectedValue);
            string Mobile = row.Cells[3].Text;
            DropDownList ddlDept = (DropDownList)row.FindControl("ddlDept");
            int Dept = Convert.ToInt32(ddlDept.SelectedValue);

            //int result = 0;
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    SqlCommand cmd = new SqlCommand("Update_Employee", conn);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@EmpId", SqlDbType.Int).Value = Convert.ToInt32(Id);
            //    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            //    cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = Gender;
            //    cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = Mobile;
            //    cmd.Parameters.Add("@DeptId", SqlDbType.Int).Value = Dept;
            //    conn.Open();
            //    result = cmd.ExecuteNonQuery();
            //}

            //if (result > 0)
            //{
            //    gvEmployee.EditIndex = -1;
            //    BindGrid();
            //}

            Employee emp = new Employee();
            emp.EmpId = Convert.ToInt32(Id);
            emp.Name = Name;
            emp.GenderId = Gender;
            emp.Mobile = Mobile;
            emp.DeptId = Dept;

            string request = JsonConvert.SerializeObject(emp);

            string response = CallAPI("https://localhost:44305/api/update", request, "PUT");

            if(response != null)
            {
                gvEmployee.EditIndex = -1;
                BindGrid();
            }
            
        }

        protected void gvEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gvEmployee.Rows[e.RowIndex];
            string Id = row.Cells[0].Text;
            //int result = 0;
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    SqlCommand cmd = new SqlCommand("Delete_Employee", conn);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@EmpId", SqlDbType.Int).Value =Convert.ToInt32(Id);
            //    conn.Open();
            //    result = cmd.ExecuteNonQuery();
            //}

            //if (result > 0)
            //{
            //    BindGrid();
            //}

            string response = CallAPI("https://localhost:44305/api/Employee/"+Id, "", "DELETE");

            if (response != null)
            {
                BindGrid();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtName.Text == "")
            {

            }
            else if (rblGender.SelectedValue == "")
            {

            }
            else if (txtMobile.Text == "")
            {

            }
            else if (txtMobile.Text.Length != 10)
            {

            }
            else if (ddlDepartment.SelectedIndex == 0)
            {

            }
            else
            {
                //int result = 0;
                //using (SqlConnection conn = new SqlConnection(connStr))
                //{
                //    SqlCommand cmd = new SqlCommand("Insert_Employee", conn);
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text.Trim();
                //    cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = rblGender.SelectedValue;
                //    cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = txtMobile.Text;
                //    cmd.Parameters.Add("@DeptId", SqlDbType.Int).Value = ddlDepartment.SelectedValue;
                //    conn.Open();
                //    result = cmd.ExecuteNonQuery();
                //}

                //if (result > 0)
                //{
                //    BindGrid();
                //}

                Employee emp = new Employee();
                emp.Name = txtName.Text.Trim();
                emp.GenderId = Convert.ToInt32(rblGender.SelectedValue);
                emp.Mobile = txtMobile.Text;
                emp.DeptId = Convert.ToInt32(ddlDepartment.SelectedValue);

                string request = JsonConvert.SerializeObject(emp);

                string response = CallAPI("https://localhost:44305/api/insert", request, "POST");

                if (response != null)
                {
                    BindGrid();
                }
            }

        }

        private void BindGrid()
        {
            //DataTable dt = new DataTable();
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    SqlCommand cmd = new SqlCommand("Get_Employee", conn);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    conn.Open();
            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    adapter.Fill(dt);
            //}
            //gvEmployee.DataSource = dt;
            //gvEmployee.DataBind();

            string response = CallAPI("https://localhost:44305/api/employee", "", "GET");
            List<Employee> emp_list = JsonConvert.DeserializeObject<List<Employee>>(response);
            gvEmployee.DataSource = emp_list;
            gvEmployee.DataBind();
        }

        private void BindDepartment(DropDownList ddl)
        {
            //DataTable dt = new DataTable();
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    SqlCommand cmd = new SqlCommand("Get_Department", conn);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    conn.Open();
            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    adapter.Fill(dt);
            //}
            //ddl.Items.Clear();
            //ddl.DataSource = dt;
            //ddl.DataTextField = "DeptName";
            //ddl.DataValueField = "DeptId";
            //ddl.DataBind();
            //ddl.Items.Insert(0,new ListItem("Select Department","0"));

            string response = CallAPI("https://localhost:44305/api/department", "", "GET");

            List<Department> dept_list = JsonConvert.DeserializeObject<List<Department>>(response);
            ddl.Items.Clear();
            ddl.DataSource = dept_list;
            ddl.DataTextField = "DeptName";
            ddl.DataValueField = "DeptId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Department", "0"));
        }

        protected void gvEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmployee.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        private string CallAPI(string url, string requestJson, string method)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback +=
             (sender, certificate, chain, sslPolicyErrors) => true;
            string result = string.Empty;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                request.ContentType = "application/json";

                if (!string.IsNullOrEmpty(requestJson))
                {
                    byte[] data = Encoding.UTF8.GetBytes(requestJson);
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }

                using (var httpResponse = (HttpWebResponse)request.GetResponse())
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                result = null;
            }

            return result;
        }
    }
}