using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class CategoryView : ContentPage
{
    public CategoryView(CategoryViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is CategoryViewModel bindingContext)
        {
            bindingContext.OnAppearing();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (BindingContext is CategoryViewModel bindingContext)
        {
            bindingContext.OnDisappearing();
        }
    }
}
