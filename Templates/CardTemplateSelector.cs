
using GenovaAI.Models;
namespace GenovaAI.Templates;


public class CardTemplateSelector :  DataTemplateSelector
{
    public DataTemplate InvestimentoTemplate { get; set; }
    public DataTemplate IATemplate { get; set;  }
    public DataTemplate RelatorioTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
            var card = item as CardInfo;
            
            var tipo = card?.Tipo?.Trim().ToLowerInvariant();
            Console.WriteLine($"Tipo processado: {tipo}");

            return tipo switch
            {
                "investimento" or "investimentopage" => InvestimentoTemplate,
                "ia" or "iapage" => IATemplate,
                "relatorio" or "relatoriopage" => RelatorioTemplate,
                _ => RelatorioTemplate
            };
        
    }
}