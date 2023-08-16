
using ApiConsumeApp.MVVM.ViewModels;

namespace ApiConsumeApp;

public partial class MainPage : ContentPage
{
	MainPageViewModel viewModel=new MainPageViewModel();
	public MainPage()
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
    protected override async void OnAppearing()
    {
        await viewModel.FillData();
    }

    private void search_TextChanged(object sender, TextChangedEventArgs e)
    {
        viewModel.FilterList(e.NewTextValue);
    }
}

