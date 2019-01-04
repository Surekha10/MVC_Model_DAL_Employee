using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;

namespace MVC_Model_DAL_Employee.Models
{
    public class EmployeeDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        public int AddEmployee(EmployeeModel model)
        {
            SqlCommand com_add = new SqlCommand("proc_addemployee", con);
            com_add.Parameters.AddWithValue("@name", model.EmployeeName);
            com_add.Parameters.AddWithValue("@city", model.EmployeeCity);
            com_add.Parameters.AddWithValue("@email", model.EmployeeEmail);
            com_add.Parameters.AddWithValue("@password", model.EmployeePassword);
            com_add.Parameters.AddWithValue("@gender", model.EmployeeGender);
            com_add.Parameters.AddWithValue("@imgaddress", model.EmpoyeeImageAddress);
            com_add.CommandType = CommandType.StoredProcedure;
            SqlParameter para_ret = new SqlParameter();
            para_ret.Direction = ParameterDirection.ReturnValue;
            com_add.Parameters.Add(para_ret);
            con.Open();
            com_add.ExecuteNonQuery();
            con.Close();
            int id = Convert.ToInt32(para_ret.Value);
            return id;
        }
        public bool Login(LoginViewModel model)
        {
            SqlCommand com_login = new SqlCommand("proc_login", con);
            com_login.Parameters.AddWithValue("@loginid", model.LoginID);
            com_login.Parameters.AddWithValue("@password", model.Password);
            com_login.CommandType = CommandType.StoredProcedure;
            SqlParameter para_ret = new SqlParameter();
            para_ret.Direction = ParameterDirection.ReturnValue;
            com_login.Parameters.Add(para_ret);
            con.Open();
            com_login.ExecuteNonQuery();
            con.Close();
            int count = Convert.ToInt32(para_ret.Value);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<SelectListItem> GetCities()
        {
            List<SelectListItem> cities = new List<SelectListItem>();
            cities.Add(new SelectListItem { Text = "Select", Value = "" });
            cities.Add(new SelectListItem { Text = "BGL", Value = "BGL" });
            cities.Add(new SelectListItem { Text = "Chennai", Value = "Chennai" });
            return cities;

        }
        public List<EmployeeProjectionModel> Search(string key)
        {
            SqlCommand com_search = new SqlCommand("proc_search", con);
            com_search.Parameters.AddWithValue("@key", key);
            com_search.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = com_search.ExecuteReader();
            List<EmployeeProjectionModel> list = new List<EmployeeProjectionModel>();
            while (dr.Read())
            {
                EmployeeProjectionModel model = new EmployeeProjectionModel();
                model.EmployeeID = dr.GetInt32(0);
                model.EmplpoyeeName = dr.GetString(1);
                model.EmployeeGender = dr.GetString(2);
                model.EmployeeImageAddress = dr.GetString(3);
                list.Add(model);
            }
            con.Close();
            return list;
        }
        public EmployeeModel Find(int id)
        {
            SqlCommand com_find = new SqlCommand("proc_find", con);
            com_find.Parameters.AddWithValue("@id", id);
            com_find.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = com_find.ExecuteReader();
            if (dr.Read())
            {
                EmployeeModel model = new EmployeeModel();
                model.EmployeeID = dr.GetInt32(0);
                model.EmployeeName = dr.GetString(1);
                model.EmployeeCity = dr.GetString(2);
                model.EmployeeEmail = dr.GetString(3);
                model.EmployeePassword = dr.GetString(4);
                model.EmployeeGender = dr.GetString(5);
                model.EmpoyeeImageAddress = dr.GetString(6);
                con.Close();
                return model;
            }
            else
            {
                con.Close();
                return null;
            }
        }
        public bool Update(int id, string password)
        {
            SqlCommand com_update = new SqlCommand("proc_update", con);
            com_update.Parameters.AddWithValue("@id", id);
            com_update.Parameters.AddWithValue("@password", password);
            com_update.CommandType = CommandType.StoredProcedure;
            SqlParameter para_return = new SqlParameter();
            para_return.Direction = ParameterDirection.ReturnValue;
            com_update.Parameters.Add(para_return);
            con.Open();
            com_update.ExecuteNonQuery();
            con.Close();
            int count = Convert.ToInt32(para_return.Value);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            SqlCommand com_delete = new SqlCommand("proc_delete", con);
            com_delete.Parameters.AddWithValue("@id", id);
            com_delete.CommandType = CommandType.StoredProcedure;
            SqlParameter para_return = new SqlParameter();
            para_return.Direction = ParameterDirection.ReturnValue;
            com_delete.Parameters.Add(para_return);
            con.Open();
            com_delete.ExecuteNonQuery();
            con.Close();
            int count = Convert.ToInt32(para_return.Value);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
    
