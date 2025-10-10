using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Repositories;

public interface ICategoryRepository
{
    public List<Category> GetAll();
    public Category? Get(int id);
    public Category? Get(string name);
    public Category Add(Category category);
    public Category? Update(Category category);
    public Category? Delete(Category category);
}