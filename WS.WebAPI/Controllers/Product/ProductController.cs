
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.Auth.ApplicationService.UserModule.Abstracts;
using WS.Auth.Dtos.UserModule;
using WS.Product.ApplicationService.ProductManagerModule.Abstracts;
using WS.Product.Dtos.ProductModule;

namespace WS.WebAPI.Controllers.Product
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Thêm user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public IActionResult CreateProduct(CreateProductDto input)
        {
            _productService.CreateProduct(input);
            return Ok();
        }
        [HttpPut("update")]
        public IActionResult UpdateProduct(UpdateProductDto input)
        {
            _productService.UpdateProduct(input);
            return Ok();
        }
        [HttpDelete("delete")]
        public IActionResult DeleteProduct(DeleteProductDto input)
        {
            _productService.DeleteProduct(input);
            return Ok();
        }
    }

}
