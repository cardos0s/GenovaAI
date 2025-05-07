using System;
using GenovaAI.ViewModels;
using Microsoft.Maui.Controls;

namespace GenovaAI.Components;

public partial class SaldoView : ContentView
{
    public SaldoView()
    {
        InitializeComponent();
        BindingContext = new SaldoViewModel(); // conecta a lógica de dados
    }

    private  async void ImageButton_OnClicked(object? sender, EventArgs e)
    {
        await Application.Current.MainPage.DisplayAlert("Título", "Mensagem", "OK");    
    }
}