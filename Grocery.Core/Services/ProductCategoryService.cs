using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public ProductCategory? Get(int id)
    {
        return _productCategoryRepository.Get(id);
    }
    public ProductCategory? Get(string name)
    {
        return _productCategoryRepository.Get(name);
    }
    public List<ProductCategory> GetAll()
    {
        return _productCategoryRepository.GetAll();
    }
    public ProductCategory Add(ProductCategory category)
    {
        return _productCategoryRepository.Add(category);
    }
    public ProductCategory? Update(ProductCategory category)
    {
        return _productCategoryRepository.Update(category);
    }

    public ProductCategory? Delete(ProductCategory category)
    {
        return _productCategoryRepository.Delete(category);
    }

    public List<Product> GetProductsForCategory(int categoryId)
    {
        return _productCategoryRepository.GetProductsByCategoryId(categoryId);
    }
    
    public ProductCategory? GetProductCategory(int productid, int categoryId)
    {
        return _productCategoryRepository.GetProductCategory(productid, categoryId);
    }

}
