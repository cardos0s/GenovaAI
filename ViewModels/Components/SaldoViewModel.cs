using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace GenovaAI.ViewModels;

public class SaldoViewModel : INotifyPropertyChanged
{
    private string _balance = "$56,304.20";
    private bool _isBalanceVisible = true;
    private string _variation = "+20.4% this month";

    public string Balance => _isBalanceVisible ? _balance : "******";
    public string Variation => _variation;

    public ICommand ToggleBalanceCommand { get; }
    public ICommand ActionCommand { get; }

    public SaldoViewModel()
    {
        ToggleBalanceCommand = new Command(ToggleBalance);
        ActionCommand = new Command<string>(ExecuteAction);
    }

    private void ToggleBalance()
    {
        _isBalanceVisible = !_isBalanceVisible;
        OnPropertyChanged(nameof(Balance));
    }

    private void ExecuteAction(string action)
    {
        Console.WriteLine($"Action triggered: {action}");
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}