using Microcharts;

namespace GenovaAI.Models;
public class CardInfo
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Tipo { get; set;  }
    public Chart Grafico { get; set; }
    public string UltimaAtualizacao { get; set; }
}