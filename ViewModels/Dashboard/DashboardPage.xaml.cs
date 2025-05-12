using GenovaAI.Components;
using GenovaAI.Models;
using GenovaAI.ViewModels;

namespace GenovaAI.Views.Dashboard;
public partial class DashboardPage : ContentPage
{
    private readonly DashboardPageViewModel viewModel = new();

    public DashboardPage()
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
    }

   
    
   
}