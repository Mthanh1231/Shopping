using Microsoft.Extensions.Logging;
using WS.Product.ApplicationService.Common;
using WS.Product.ApplicationService.ProductManagerModule.Abstracts;
using WS.Product.Domain;
using WS.Product.Dtos.ProductModule;
using WS.Product.Infrastructure;
using WS.Shared.ApplicationService.User;

namespace WS.Product.ApplicationService.ProductManagerModule.Implements
{
    public class ProductService : ProductServiceBase, IProductService
    {
        private readonly IUserInforService _userInforService;
        private readonly ProductDbContext _dbContext;

        public ProductService(ILogger<ProductService> logger, ProductDbContext dbContext, IUserInforService userInforService)
            : base(logger, dbContext)
        {
            _userInforService = userInforService;
            _dbContext = dbContext;
        }

        public void CreateProduct(CreateProductDto input)
        {
            var product = new ProdProduct
            {
                Name = input.Name,
                Quantity = input.Quantity,
                //CreatedBy = _userInforService.GetCurrentUserId(),
                //CreatedDate = DateTime.Now
            };

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }
        public void UpdateProduct(UpdateProductDto input)
        {
            var product = _dbContext.Products.Find(input.Id);

            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }

            product.Name = input.Name;
            product.Quantity = input.Quantity;

            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(DeleteProductDto input)
        {
            var product = _dbContext.Products.Find(input);

            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}
