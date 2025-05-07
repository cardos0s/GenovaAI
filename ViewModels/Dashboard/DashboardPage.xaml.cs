using GenovaAI.Models;
using GenovaAI.ViewModels;

namespace GenovaAI.View;

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
        await viewModel.CarregarCotacaoAsync();
        await viewModel.AtualizarGraficoInvestimentoAsync();
    }

    private async void InvestimentoTapped(object? sender, TappedEventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is CardInfo)
        {
            await Navigation.PushAsync(new InvestmentPage());
        }
    }

    private async void IATapped(object? sender, TappedEventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is CardInfo)
        {
            await Navigation.PushAsync(new IAPage("bitcoin"));
        }
    }

    private async void RelatorioTapped(object? sender, TappedEventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is CardInfo)
        {
            await Navigation.PushAsync(new RelatorioPage());
        }
    }

    private async void OnDashboardTapped(object? sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RelatorioPage());
    }

    private void OnMostrarOcultarClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}