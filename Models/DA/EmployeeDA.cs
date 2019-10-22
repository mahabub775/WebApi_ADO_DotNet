using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using WebApi_ADO_DotNet.Models;
using WebApi_ADO_DotNet.Models.BO;
using System.Data;
namespace WebApi_ADO_DotNet.Models.DA
{
    
    public class EmployeeDA
    {
        public static SqlDataReader IUD(DBConnection Conn, Employee oEmployee,int nDBOperation)
        {
            SqlCommand oSqlCommand = new SqlCommand();
            oSqlCommand.CommandText = "[SaveEmployee]";
            oSqlCommand.Connection = Conn.oConn;//connection Establish
            oSqlCommand.CommandType = CommandType.StoredProcedure;
            oSqlCommand.Parameters.Add(new SqlParameter("@EmployeeID", oEmployee.EmployeeID));
            oSqlCommand.Parameters.Add(new SqlParameter("@Phone", oEmployee.Phone));
            oSqlCommand.Parameters.Add(new SqlParameter("@Name", oEmployee.Name));
            oSqlCommand.Parameters.Add(new SqlParameter("@Salary", oEmployee.Salary));
            oSqlCommand.Parameters.Add(new SqlParameter("@DOB", oEmployee.DOB));
            oSqlCommand.Parameters.Add(new SqlParameter("@DBOperation", nDBOperation));
            return oSqlCommand.ExecuteReader();
        }

        public static SqlDataReader Gets(DBConnection Conn)
        {
            SqlCommand oSqlCommand = new SqlCommand();
            oSqlCommand.CommandText = "SELECT * FROM [Employee]";
            oSqlCommand.Connection = Conn.oConn;//connection Establish
            oSqlCommand.CommandType = CommandType.Text;
            return oSqlCommand.ExecuteReader();
        }
    }
}
