using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi_ADO_DotNet.Models.BO;
using WebApi_ADO_DotNet.Models.DA;
using System.Data.SqlClient;

namespace WebApi_ADO_DotNet.Models.Service
{
   public class EmployeeService
   {
        DBConnection Conn = new DBConnection();
       #region Map Objects
       private Employee MapObject(SqlDataReader oReader)
       {
           Employee oEmployee = new Employee();
           oEmployee.EmployeeID = Convert.ToInt32(oReader["EmployeeID"]);
           oEmployee.Name = Convert.ToString(oReader["Name"]);
           oEmployee.Phone = Convert.ToString(oReader["Phone"]);
           oEmployee.Salary = Convert.ToDouble(oReader["Salary"]);
            oEmployee.DOB = Convert.ToDateTime(oReader["DOB"]);
            return oEmployee;
       }
       private Employee CreateObject(SqlDataReader oReader)
       {
           Employee oEmployee =new Employee();
           oEmployee = MapObject(oReader);
           return oEmployee;
       }
       private List<Employee> CreateObjects(SqlDataReader oReader)
       {
           List<Employee> oEmployees = new List<Employee>();
           while(oReader.Read())
           {
               Employee oEmployee = new Employee();
               oEmployee = CreateObject(oReader);
               oEmployees.Add(oEmployee);
           }
           return oEmployees;
       }
       #endregion

       #region Functions
       public Employee Save(Employee oProudct)
       {
           Conn.Open();
           SqlDataReader oReader = null;
           if (oProudct.EmployeeID <= 0)
           {
               oReader = EmployeeDA.IUD(Conn, oProudct, 1);
           }
           else
           {
               oReader = EmployeeDA.IUD(Conn, oProudct,2);
           }
           if (oReader.Read())
           {
               oProudct = CreateObject(oReader);
           }
           Conn.Close();
           return oProudct;
       }

       public  List<Employee> Gets()
       {
           List<Employee> oEmployees = new List<Employee>();
           Conn.Open();
           SqlDataReader oReader = null;
           oReader = EmployeeDA.Gets(Conn);
           if (oReader.Read())
           {
               oEmployees = CreateObjects(oReader);
           }
           Conn.Close();
           return oEmployees;
       }
       #endregion
   }
}
