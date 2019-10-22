using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi_ADO_DotNet.Models.Service;

namespace WebApi_ADO_DotNet.Models.BO
{
    public class Employee
    {
       public Employee()
        {
            EmployeeID = 0;//PK
            Name = "";
            Phone = "";
            Salary = 0;
            DOB = new DateTime(1755,1,1);//Default  min Date date 
        }
        #region Variables
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public double Salary { get; set; }
        public DateTime DOB { get; set; }
        #endregion
        #region Derived Properties
        public string DOBSt
        {
            get
            {
                return this.DOB != new DateTime(1755, 1, 1) ? this.DOB.ToString("dd MMM yyyy") : "";
            }
        }
        #endregion

        #region Functions
        public static List<Employee> Gets()
        {
            EmployeeService oEmployeeService = new EmployeeService();
            return oEmployeeService.Gets();
        }
        public Employee Save(Employee oEmployee)
        {
            EmployeeService oEmployeeService = new EmployeeService();
            return oEmployeeService.Save(oEmployee);
        }
        public string Delete(int ID)
        {
            return "Deleted";
        }
        #endregion
    }
}
