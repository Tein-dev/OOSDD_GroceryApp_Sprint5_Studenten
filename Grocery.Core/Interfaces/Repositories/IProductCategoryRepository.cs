using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Repositories;

public interface IProductCategoryRepository
{
    public ProductCategory? Get(int id);
    public ProductCategory? Get(string name);
    public List<ProductCategory> GetAll();
    public ProductCategory Add(ProductCategory category);
    public ProductCategory? Update(ProductCategory category);
    public ProductCategory? Delete(ProductCategory category);
    public List<Product> GetProductsByCategoryId(int categoryId);
    public ProductCategory? GetProductCategory(int productid, int categoryId);
}
