namespace Grocery.Core.Models;

public class Category : Model
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public Category(int id, string name) : base(id, name)
    {
        Id = id;
        Name = name;
    }
}