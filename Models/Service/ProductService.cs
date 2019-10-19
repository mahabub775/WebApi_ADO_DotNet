using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi_ADO_DotNet.Models.BO;
using WebApi_ADO_DotNet.Models.DA;
using System.Data.SqlClient;

namespace WebApi_ADO_DotNet.Models.Service
{
   public class ProductService
   {
        DBConnection Conn = new DBConnection();
       #region Map Objects
       private Product MapObject(SqlDataReader oReader)
       {
           Product oProduct = new Product();
           oProduct.ProductID = Convert.ToInt32(oReader["ProductID"]);
           oProduct.ProductName = Convert.ToString(oReader["Name"]);
           oProduct.ProductCode = Convert.ToString(oReader["Code"]);
           oProduct.UnitID = Convert.ToInt32(oReader["SmallUnit"]);
           return oProduct;
       }
       private Product CreateObject(SqlDataReader oReader)
       {
           Product oProduct =new Product();
           oProduct = MapObject(oReader);
           return oProduct;
       }
       private List<Product> CreateObjects(SqlDataReader oReader)
       {
           List<Product> oProducts = new List<Product>();
           while(oReader.Read())
           {
               Product oProduct = new Product();
               oProduct = CreateObject(oReader);
               oProducts.Add(oProduct);
           }
           return oProducts;
       }
       #endregion

       #region Functions
       public Product Save(Product oProudct)
       {
           Conn.Open();
           SqlDataReader oReader = null;
           if (oProudct.ProductID <= 0)
           {
               oReader = ProductDA.IUD(Conn, oProudct, 1);
           }
           else
           {
               oReader = ProductDA.IUD(Conn, oProudct,2);
           }
           if (oReader.Read())
           {
               oProudct = CreateObject(oReader);
           }
           Conn.Close();
           return oProudct;
       }

       public  List<Product> Gets()
       {
           List<Product> oProducts = new List<Product>();
           Conn.Open();
           SqlDataReader oReader = null;
           oReader = ProductDA.Gets(Conn);
           if (oReader.Read())
           {
               oProducts = CreateObjects(oReader);
           }
           Conn.Close();
           return oProducts;
       }
       #endregion
   }
}
