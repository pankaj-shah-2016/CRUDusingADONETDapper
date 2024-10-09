using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUDusingDapper.Models;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Data;

namespace CRUDusingDapper.Repository
{
    public class EmpRepository
    {
        public SqlConnection con;
             
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            con = new SqlConnection(constr);
        }
            
        public void AddEmployee(EmpModel objEmp)
        {   
            try
            {
                connection();
                con.Open();
                con.Execute("AddNewEmpDetails", objEmp, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            
        public List<EmpModel> GetAllEmployees()
        {
            try
            {
                connection();
                con.Open();
                IList<EmpModel> EmpList = SqlMapper.Query<EmpModel>(con, "GetEmployees").ToList();
                con.Close();
                return EmpList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //To Update Employee details      
        public void UpdateEmployee(EmpModel objEmp)
        {
            try
            {
                connection();
                con.Open();
                con.Execute("UpdateEmpDetails", objEmp, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
             
        public bool DeleteEmployee(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmpId", Id);
                connection();
                con.Open();
                con.Execute("DeleteEmpById", param, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                //Log error as per your need       
                throw ex;
            }
        }
    }
}