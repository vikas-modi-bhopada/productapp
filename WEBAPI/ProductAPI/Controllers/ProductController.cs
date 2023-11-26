using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Model;
using ProductAPI.Service;

namespace ProductAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("GetAllProduct")]
        [HttpGet]

        public ActionResult GetAllUsers()
        {
            List<Product> users = _productService.GetAllUsers();
            return Ok(users);
        }

        [Route("AddProduct")]
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            bool AddProductStatus=_productService.AddProduct(product);
            return Ok(AddProductStatus);
        }
        [Route("DeleteProduct")]
        [HttpDelete]

        public ActionResult DeleteProduct(int id)
        {
            bool DeleteProductStatus = _productService.DeleteProduct(id);
            return Ok(DeleteProductStatus);
        }

        [Route("UpdateProduct/{id:int}")]
        [HttpPut]
        public ActionResult UpadteProduct(int id, Product product)
        {
            bool UpdateProductStatus = _productService.UpdateProduct(id, product);
            return Ok(UpdateProductStatus);
        }

        [Route("GetProductById/{id:int}")]
        [HttpGet]
        public ActionResult GetProductById(int id)
        {
            Product product = _productService.GetProductById(id);
            return Ok(product);
        }


    }
}
