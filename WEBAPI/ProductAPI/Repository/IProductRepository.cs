using ProductAPI.Model;

namespace ProductAPI.Repository
{
    public interface IProductRepository
    {
        object GetProductByName(string name);
        int AddProduct(Product product);
        Product GetProductById(int id);
        int DeleteProduct(Product productExist);
        List<Product> GetAllProduct();
        int UpdateProduct(Product product);
    }
}
