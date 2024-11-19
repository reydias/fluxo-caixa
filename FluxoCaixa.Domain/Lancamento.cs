namespace FluxoCaixa.Domain
{
    public class Lancamento
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; } = string.Empty; // "débito" ou "crédito"
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
