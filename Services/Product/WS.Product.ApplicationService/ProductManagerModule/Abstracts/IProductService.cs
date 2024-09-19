using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Product.Dtos.ProductModule;

namespace WS.Product.ApplicationService.ProductManagerModule.Abstracts
{
    public interface IProductService
    {
        void CreateProduct(CreateProductDto input);
        void UpdateProduct(UpdateProductDto input);
        void DeleteProduct(DeleteProductDto input);
    }
}
