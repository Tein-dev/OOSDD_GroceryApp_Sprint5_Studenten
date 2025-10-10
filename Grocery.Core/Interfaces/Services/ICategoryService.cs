using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services;

public interface ICategoryService
{
    public Category? Get(int id);
    public Category? Get(string name);
    public List<Category> GetAll();
    public Category Add(Category category);
    public Category? Update(Category category);
    public Category? Delete(Category category);
}