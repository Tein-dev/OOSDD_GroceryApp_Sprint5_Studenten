using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public Category? Get(int id)
    {
        return _categoryRepository.Get(id);
    }
    public Category? Get(string name)
    {
        return _categoryRepository.Get(name);
    }

    public List<Category> GetAll()
    {
        return _categoryRepository.GetAll();
    }
    public Category Add(Category category)
    {
        return _categoryRepository.Add(category);
    }

    public Category? Update(Category category)
    {
        return _categoryRepository.Update(category);
    }
    public Category? Delete(Category category)
    {
        return _categoryRepository.Delete(category);
    }
}