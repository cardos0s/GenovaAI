using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GenovaAI.Models;
using GenovaAI.Services;
using Microcharts;
using SkiaSharp;

namespace GenovaAI.ViewModels
{
    public class DashboardPageViewModel : INotifyPropertyChanged
    {
        private readonly CryptoServices _cryptoService = new();
        
        private readonly CotacaoServices _service = new();
        public ObservableCollection<CardInfo> ListaDeCards { get; set; }

        private string _dolar;
        public string Dolar
        {
            get => _dolar;
            set
            {
                _dolar = value;
                OnPropertyChanged();
            }
        }

        public DashboardPageViewModel()
        {
            ListaDeCards = new ObservableCollection<CardInfo>
            {
                new CardInfo
                {
                    Titulo = "💰 Investimento!",
                    Descricao = "Aprenda a controlar suas finanças com Genova AI.",
                    Tipo = "InvestimentoPage",
                    Grafico = new LineChart
                    {
                        Entries = new[]
                        {
                            new ChartEntry(342000) { Label = "BTC", ValueLabel = "342k", Color = SKColor.Parse("#f7931a") },
                            new ChartEntry(18500) { Label = "ETH", ValueLabel = "18.5k", Color = SKColor.Parse("#3c3cff") },
                            new ChartEntry(128000) { Label = "IBOV", ValueLabel = "128k", Color = SKColor.Parse("#00c853") },
                        },
                        LineMode = LineMode.Straight,
                        LineSize = 4,
                        PointSize = 6
                    }
                },
                new CardInfo
                {
                    Titulo = "📈 Relatório Econômico de Hoje",
                    Descricao = "Atualização.",
                    Tipo = "RelatorioPage"
                },
                new CardInfo
                {
                    Titulo = "IA que ajuda com seu planejamento!",
                    Descricao = "Evite dívidas com planejamento semanal.",
                    Tipo = "IAPage"
                }
            };
        }

        public async Task CarregarCotacaoAsync()
        {
            var cotacao = await _service.GetCotacaoDolarAsync();
            if (cotacao != null)
                Dolar = $"💵 Dólar: R$ {cotacao.high}";
            else
                Dolar = "Erro ao carregar dólar 😢";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
        public async Task AtualizarGraficoInvestimentoAsync()
        {
            var cotacoes = await _cryptoService.ObterCotacoesAsync();
            if (cotacoes == null) return;

            var novoGrafico = new DonutChart
            {
                Entries = new[]
                {
                    new ChartEntry((float)cotacoes["BTC"])
                    {
                        Label = "BTC",
                        ValueLabel = "R$ " + cotacoes["BTC"].ToString("N0"),
                        Color = SKColor.Parse("#F7931A")
                    },
                    new ChartEntry((float)cotacoes["ETH"])
                    {
                        Label = "ETH",
                        ValueLabel = "R$ " + cotacoes["ETH"].ToString("N0"),
                        Color = SKColor.Parse("#3C3CFF")
                    },
                },
                HoleRadius = 0.6f
            };

            var card = ListaDeCards.FirstOrDefault(c => c.Tipo?.ToLower().Contains("investimento") == true);
            if (card != null)
            {
                card.UltimaAtualizacao = $"Atualizado às {DateTime.Now:HH:mm}";
                OnPropertyChanged(nameof(ListaDeCards)); // força atualização no binding
            }
        }
    }
}