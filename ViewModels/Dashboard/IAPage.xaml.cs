using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenovaAI.View;

public partial class IAPage : ContentPage
{
    public IAPage(string moeda)
    {
        InitializeComponent();

        // Localhost no Android = 10.0.2.2 | No iOS = localhost direto no simulador
#if ANDROID
        string url = $"http://10.0.2.2:8000/grafico-html/{moeda}";
#else
        string url = $"http://localhost:8000/grafico-html/{moeda}";
#endif

        GraficoWebView.Source = url;
    }
}
