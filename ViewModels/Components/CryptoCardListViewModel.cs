using System.Collections.ObjectModel;
using System.Windows.Input;
using GenovaAI.Services;

namespace GenovaAI.ViewModels;

public class CryptoCardListViewModel : BaseViewModel
{
    private readonly CryptoServices _cryptoService;
    private bool _showBalance = true;

    public ObservableCollection<CryptoCardViewModel> Cards { get; } = new();

    public ICommand ToggleBalanceCommand { get; }

    public CryptoCardListViewModel(CryptoServices cryptoService)
    {
        _cryptoService = cryptoService;
        ToggleBalanceCommand = new Command(async () => await ToggleBalanceAsync());
        _ = LoadCardsAsync();
    }

    private async Task ToggleBalanceAsync()
    {
        _showBalance = !_showBalance;
        await LoadCardsAsync();
    }

    public async Task LoadCardsAsync()
    {
        var prices = await _cryptoService.GetCryptoPricesAsync();
        if (prices == null) return;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Cards.Clear();
            foreach (var kvp in prices)
            {
                Cards.Add(new CryptoCardViewModel
                {
                    Name = kvp.Key,
                    Price = _showBalance ? kvp.Value : 0
                });
            }
        });
    }
}