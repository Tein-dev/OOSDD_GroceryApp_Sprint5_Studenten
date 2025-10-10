using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.App.Views;

namespace Grocery.App.ViewModels;

public partial class CategoryViewModel : BaseViewModel
{
    private readonly ICategoryService _categoryService;
    public ObservableCollection<Category> Categories { get; set; } = [];

    public CategoryViewModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public override void OnAppearing()
    {
        base.OnAppearing();
        LoadCategories();
    }

    private void LoadCategories()
    {
        Categories.Clear();
        var categories = _categoryService.GetAll();
        foreach (Category c in categories)
        {
            Categories.Add(c);
        }
    }

    [RelayCommand]
    private async Task GoToProductCategory(Category category)
    {
        if (category == null) return;
        await Shell.Current.GoToAsync(nameof(ProductCategoryView), new Dictionary<string, object>
        {
            // The key "Category" must match the QueryProperty in ProductCategoryViewModel
            { "Category", category }
        });
    }
}
