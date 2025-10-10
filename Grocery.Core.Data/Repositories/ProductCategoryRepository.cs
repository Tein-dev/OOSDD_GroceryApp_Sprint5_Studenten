using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly List<ProductCategory> _productCategories;
    private readonly IProductRepository _productRepository;

    public ProductCategoryRepository(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<ProductCategory> GetAll()
    {
        return _productCategories;
    }

    public ProductCategory? Get(int id)
    {
        return _productCategories.FirstOrDefault(pc => pc.Id == id);
    }

    public ProductCategory? Get(string name)
    {
        return _productCategories.FirstOrDefault(pc => pc.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public ProductCategory Add(ProductCategory productCategory)
    {
        int newId = _productCategories.Count > 0 ? _productCategories.Max(pc => pc.Id) + 1 : 1;
        productCategory.Id = newId;
        _productCategories.Add(productCategory);
        return productCategory;
    }

    public ProductCategory? Update(ProductCategory productCategory)
    {
        ProductCategory? existingProductCategory = _productCategories.FirstOrDefault(pc => pc.Id == productCategory.Id);
        if (existingProductCategory != null)
        {
            existingProductCategory.Name = productCategory.Name;
            existingProductCategory.CategoryId = productCategory.CategoryId;
            existingProductCategory.ProductId = productCategory.ProductId;
        }

        return existingProductCategory;
    }

    public ProductCategory? Delete(ProductCategory productCategory)
    {
        ProductCategory? existingProductCategory = _productCategories.FirstOrDefault(pc => pc.Id == productCategory.Id);
        if (existingProductCategory != null)
        {
            _productCategories.Remove(existingProductCategory);
        }

        return existingProductCategory;
    }

    public List<Product> GetProductsByCategoryId(int categoryId)
    {
        var productIds = _productCategories
            .Where(pc => pc.CategoryId == categoryId)
            .Select(pc => pc.ProductId)
            .ToHashSet();

        return _productRepository.GetAll()
            .Where(p => productIds.Contains(p.Id))
            .ToList();
    }

    public ProductCategory? GetProductCategory(int productId, int categoryId)
    {
        return _productCategories.FirstOrDefault(pc => pc.ProductId == productId && pc.CategoryId == categoryId);
    }
}
