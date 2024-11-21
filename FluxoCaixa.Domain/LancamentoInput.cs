using FluxoCaixa.Domain;

namespace FluxoCaixa.Api
{
    public class LancamentoInput
    {
        public string Tipo { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
