namespace Grocery.Core.Models;

public class ProductCategory : Model
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public ProductCategory(int id, string name, int productId, int categoryId) : base(id, name)
    {
        Id = id;
        Name = name;
        ProductId = productId;
        CategoryId = categoryId;
    }
}