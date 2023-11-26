using ProductAPI.Model;

namespace ProductAPI.Service
{
    public interface IProductService
    {
        bool AddProduct(Product product);
        bool UpdateProduct(int id, Product product);
        bool DeleteProduct(int id);
        List<Product> GetAllUsers();
        Product GetProductById(int id);
    }
}
