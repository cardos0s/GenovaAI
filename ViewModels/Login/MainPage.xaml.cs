using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenovaAI.View;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new DashboardPage());
        
    }
}