using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2
{
    [RoutePrefix("api")]
    public class EmployeeController : ApiController
    {
        string connStr = "Data Source=SAUMITA; Initial Catalog=Employee; User Id=sa; Password=sa@123; Trusted_Connection=True;";
        // GET api/<controller>
        [HttpGet]
        [Route("department")]
        public IHttpActionResult GetDepartment()
        {
            List<Department> list = new List<Department>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("Get_Department", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Department
                        {
                            DeptId = Convert.ToInt32(reader["DeptId"]),
                            DeptName = reader["DeptName"].ToString()
                        });
                    }
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/<controller>
        [HttpGet]
        [Route("employee")]
        public IHttpActionResult GetEmployee()
        {
            List<Employee> list = new List<Employee>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("Get_Employee", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Employee
                        {
                            EmpId = Convert.ToInt32(reader["EmpId"]),
                            Name = reader["Name"].ToString(),
                            Mobile = reader["Mobile"].ToString(),
                            GenderId = Convert.ToInt32(reader["GenderId"]),
                            Gender = reader["Gender"].ToString(),
                            DeptId = Convert.ToInt32(reader["DeptId"]),
                            DeptName = reader["DeptName"].ToString(),
                        });
                    }
                }

                    return Ok(list);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Employee emp = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("Get_Employee_ById", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmpId", SqlDbType.Int).Value = id;
                    cmd.CommandTimeout = 0;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        emp = new Employee
                        {
                            EmpId = Convert.ToInt32(reader["EmpId"]),
                            Name = reader["Name"].ToString(),
                            Mobile = reader["Mobile"].ToString(),
                            GenderId = Convert.ToInt32(reader["GenderId"]),
                            Gender = reader["Gender"].ToString(),
                            DeptId = Convert.ToInt32(reader["DeptId"]),
                            DeptName = reader["DeptName"].ToString(),
                        };
                    }
                }

                if (emp == null)
                    return NotFound();
                else
                    return Ok(emp);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // POST api/<controller>
        [HttpPost]
        [Route("insert")]
        public IHttpActionResult Post(Employee emp)
        {
            if (emp == null)
            {
                return BadRequest("Request is Empty");
            }

            int result = 0; 
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("Insert_Employee", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = emp.Name;
                    cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = emp.GenderId;
                    cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = emp.Mobile;
                    cmd.Parameters.Add("@DeptId", SqlDbType.Int).Value = emp.DeptId;
                    cmd.CommandTimeout = 0;
                    conn.Open();
                    result = cmd.ExecuteNonQuery();

                }

                if (result > 0)
                    return Ok("Successfully Submitted");
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Put(Employee emp)
        {
            if(emp == null)
            {
                return BadRequest("Request is Empty");
            }

            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("Update_Employee", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmpId", SqlDbType.Int).Value = emp.EmpId;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = emp.Name;
                    cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = emp.GenderId;
                    cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = emp.Mobile;
                    cmd.Parameters.Add("@DeptId", SqlDbType.Int).Value = emp.DeptId;
                    cmd.CommandTimeout = 0;
                    conn.Open();
                    result = cmd.ExecuteNonQuery();

                }

                if (result > 0)
                    return Ok("Updated Successfully");
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("Delete_Employee", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmpId", SqlDbType.Int).Value = id;
                    cmd.CommandTimeout = 0;
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }

                if (result > 0)
                    return Ok("Deleted Successfully");
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}