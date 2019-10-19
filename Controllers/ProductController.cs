using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_ADO_DotNet.Models.BO;
namespace WebApi_ADO_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Declaration
        Product _oProduct = new Product();
        List<Product> _oProducts = new List<Product>();
        #endregion


        //[Produces("application/json")]
        [HttpGet]
        public async Task <ActionResult<IEnumerable<Product>>> GetProducts()
        {
            List<Product> _oProducts = new List<Product>();
            Product oProduct = new Product();
            _oProducts = Product.Gets();
            return  _oProducts.ToList();
        }
    }
}