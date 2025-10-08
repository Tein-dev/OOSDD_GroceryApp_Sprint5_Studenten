using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services;

public interface IProductCategoryService
{
    public ProductCategory? Get(int id);
    public ProductCategory? Get(string name);
    public List<ProductCategory> GetAll();
    public ProductCategory Add(ProductCategory category);
    public ProductCategory? Update(ProductCategory category);
    public ProductCategory? Delete(ProductCategory category);
    List<Product> GetProductsForCategory(int categoryId);
}
