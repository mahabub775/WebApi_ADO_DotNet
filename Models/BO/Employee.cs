using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_ADO_DotNet.Models
{
    public class Employee
    {
        Employee()
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
    }
}
