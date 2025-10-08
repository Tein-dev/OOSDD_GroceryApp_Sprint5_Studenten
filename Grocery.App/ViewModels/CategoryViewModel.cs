using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.App.ViewModels;

public partial class CategoryViewModel : BaseViewModel
{
    private readonly ICategoryService _categoryService;
    public ObservableCollection<Category> Categories { get; set; }
    public CategoryViewModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
        Categories = [];
        foreach (Category c in _categoryService.GetAll()) Categories.Add(c);
    }
    
    [RelayCommand]
    private void GoToProductCategory(Category category)
    {
        if (category == null) return;
        Shell.Current.GoToAsync(nameof(Views.ProductCategoryView), new Dictionary<string, object>
        {
            { nameof(category), category }
        });
    }
}