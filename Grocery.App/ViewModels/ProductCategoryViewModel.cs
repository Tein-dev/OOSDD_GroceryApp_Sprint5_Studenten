using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(Category), nameof(Category))]
    public partial class ProductCategoryViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private string _searchText = "";

        public ObservableCollection<Product> ProductsInCategory { get; } = new();
        public ObservableCollection<Product> AvailableProducts { get; } = new();

        [ObservableProperty]
        private Category _category;

        public ProductCategoryViewModel(IProductCategoryService productCategoryService, IProductService productService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
        }

        partial void OnCategoryChanged(Category value)
        {
            if (value != null)
            {
                Title = value.Name;
                LoadProducts(value.Id);
            }
        }

        private void LoadProducts(int categoryId)
        {
            ProductsInCategory.Clear();
            var productsInCat = _productCategoryService.GetProductsForCategory(categoryId);
            foreach (var product in productsInCat)
            {
                ProductsInCategory.Add(product);
            }
            GetAvailableProducts();
        }

        private void GetAvailableProducts()
        {
            AvailableProducts.Clear();
            var allProducts = _productService.GetAll();
            var productsInCatIds = new HashSet<int>(ProductsInCategory.Select(p => p.Id));

            foreach (var product in allProducts)
            {
                bool isInCategory = productsInCatIds.Contains(product.Id);
                bool matchesSearch = string.IsNullOrWhiteSpace(_searchText) || product.Name.ToLower().Contains(_searchText.ToLower());

                if (!isInCategory && matchesSearch)
                {
                    AvailableProducts.Add(product);
                }
            }
        }

        [RelayCommand]
        private void AddProductToCategory(Product product)
        {
            if (product == null || Category == null) return;

            var newProductCategory = new ProductCategory(0, $"{product.Name} in {Category.Name}", product.Id, Category.Id);
            _productCategoryService.Add(newProductCategory);

            ProductsInCategory.Add(product);
            AvailableProducts.Remove(product);
        }
        
        [RelayCommand]
        private void RemoveProductFromCategory(Product product)
        {
            if (product == null || Category == null) return;

            var productCategory = _productCategoryService.GetProductCategory(product.Id, Category.Id);
            if (productCategory != null)
            {
                _productCategoryService.Delete(productCategory);
            }

            ProductsInCategory.Remove(product);
            AvailableProducts.Add(product);
        }

        [RelayCommand]
        private void PerformSearch(string searchText)
        {
            _searchText = searchText;
            GetAvailableProducts();
        }
    }
}
