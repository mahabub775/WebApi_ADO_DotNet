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
    
    public class ProductDA
    {
        public static SqlDataReader IUD(DBConnection Conn, Product oProduct,int nDBOperation)
        {
            SqlCommand oSqlCommand = new SqlCommand();
            oSqlCommand.CommandText = "[SaveProduct]";
            oSqlCommand.Connection = Conn.oConn;//connection Establish
            oSqlCommand.CommandType = CommandType.StoredProcedure;
            oSqlCommand.Parameters.Add(new SqlParameter("@ProductID", oProduct.ProductID));
            oSqlCommand.Parameters.Add(new SqlParameter("@ProductCode", "PC-9955"));
            oSqlCommand.Parameters.Add(new SqlParameter("@ProductName", oProduct.ProductName));
            oSqlCommand.Parameters.Add(new SqlParameter("@UnitID", oProduct.UnitID));
            oSqlCommand.Parameters.Add(new SqlParameter("@DBOperation", nDBOperation));
            return oSqlCommand.ExecuteReader();
        }

        public static SqlDataReader Gets(DBConnection Conn)
        {
            SqlCommand oSqlCommand = new SqlCommand();
            oSqlCommand.CommandText = "SELECT * FROM [Product]";
            oSqlCommand.Connection = Conn.oConn;//connection Establish
            oSqlCommand.CommandType = CommandType.Text;
            return oSqlCommand.ExecuteReader();
        }
    }
}
