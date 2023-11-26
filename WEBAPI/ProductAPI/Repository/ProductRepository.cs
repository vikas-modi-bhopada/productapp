using ProductAPI.Model;
using ProductAPI.Context;
using Microsoft.EntityFrameworkCore;


namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        readonly ProductDbContext _productDbcontext;
        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbcontext = productDbContext;
        }
        public int AddProduct(Product product)
        {
            
            _productDbcontext.Products.Add(product);
            return _productDbcontext.SaveChanges();
        }

        public int DeleteProduct(Product productExist)
        {
            _productDbcontext.Products.Remove(productExist);
            return _productDbcontext.SaveChanges(); 
        }

        public List<Product> GetAllProduct()
        {
            return _productDbcontext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _productDbcontext.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public object GetProductByName(string name)
        {
            return _productDbcontext.Products.Where(p => p.Name == name).FirstOrDefault();
        }

        public int UpdateProduct(Product product)
        {
            _productDbcontext.Entry(product).State=EntityState.Modified;
            return _productDbcontext.SaveChanges();
        }
    }
}
