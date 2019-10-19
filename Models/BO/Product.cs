using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi_ADO_DotNet.Models.Service;
namespace WebApi_ADO_DotNet.Models.BO
{
    public class Product
    {
        public Product()
        {
            ProductID = 0;
            ProductName = "";
            ProductCode = "P-c/2222";
            UnitID = 0;
            ErrorMesage = "";
        }
        #region Property
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string  ProductCode { get; set; }
        public int UnitID { get; set; }
        public string ErrorMesage { get; set; }
        #endregion
        #region dervive
        public string MUnitName
        {
            get
            {
                if (this.UnitID == 1) { return "Piece"; }
                else if (this.UnitID == 2) { return "Dozen"; }
                else return "";
            }
        }
        #endregion

        #region Functions
        public static List<Product> Gets()
        {
            ProductService oProductService = new ProductService();
            return oProductService.Gets();
        }
        public Product Save(Product oProduct)
        {
            ProductService oProductService = new ProductService();
            return oProductService.Save(oProduct);
        }
        public string Delete(int ID)
        {
            return "Deleted";
        }
        #endregion
    }
    public interface IProductService
    {

    }
}
