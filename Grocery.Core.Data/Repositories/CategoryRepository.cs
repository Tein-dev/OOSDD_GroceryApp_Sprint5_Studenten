using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly List<Category> _categories;
    
    public CategoryRepository()
    {
        _categories =
        [
            new Category(1, "Fruits & Vegetables"),
            new Category(2, "Dairy & Eggs"),
            new Category(3, "Meat & Seafood"),
            new Category(4, "Bakery"),
            new Category(5, "Pantry Staples"),
            new Category(6, "Beverages"),
            new Category(7, "Snacks & Sweets"),
            new Category(8, "Frozen Foods"),
            new Category(9, "Household Supplies"),
            new Category(10, "Personal Care")
        ];
    }
    public List<Category> GetAll()
    {
        return _categories;
    }
    public Category? Get(int id)
    {
        return _categories.FirstOrDefault(c => c.Id == id);
    }
    public Category? Get(string name)
    {
        return _categories.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Category Add(Category category)
    {
        int newId = _categories.Max(c => c.Id) + 1;
        category.Id = newId;
        _categories.Add(category);
        return category;
    }
    public Category? Update(Category category)
    {
        Category? existingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
        if (existingCategory != null)
        {
            existingCategory.Name = category.Name;
        }
        return existingCategory;
    }

    public Category? Delete(Category category)
    {
        Category? existingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
        if (existingCategory != null)
        {
            _categories.Remove(existingCategory);
        }
        return existingCategory;
    }
}