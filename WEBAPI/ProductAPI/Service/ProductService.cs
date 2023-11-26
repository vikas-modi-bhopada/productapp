using ProductAPI.Model;
using ProductAPI.Repository;

namespace ProductAPI.Service
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool AddProduct(Product product)
        {
            var productExist = _productRepository.GetProductByName(product.Name);
            if (productExist == null)
            {
                int AddProductStatus = _productRepository.AddProduct(product);
                if (AddProductStatus == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }

        public bool DeleteProduct(int id)
        {
            Product ProductExist = _productRepository.GetProductById(id);
            if (ProductExist != null)
            {
                int ProductDeleteStatus = _productRepository.DeleteProduct(ProductExist);
                if (ProductDeleteStatus == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<Product> GetAllUsers()
        {
            return _productRepository.GetAllProduct();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public bool UpdateProduct(int id, Product product)
        {
            product.Id = id;
            int ProductEditStatus = _productRepository.UpdateProduct(product);
            if (ProductEditStatus == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
