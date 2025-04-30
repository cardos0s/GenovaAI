namespace GenovaAI.Models;

public class Cotacao
{
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; }
        public string high { get; set; } // valor mais alto (útil pro app)
}