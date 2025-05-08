using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenovaAI.Services;
using System.Threading.Tasks;
using GenovaAI.ViewModels;

namespace GenovaAI.Components;

public partial class CryptoCardList : ContentView
{
    public CryptoCardList()
    {
        InitializeComponent();
        BindingContext = App.ServiceProvider.GetService<CryptoCardListViewModel>();
    }
}