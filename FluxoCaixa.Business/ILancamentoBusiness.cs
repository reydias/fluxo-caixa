using FluxoCaixa.Domain;

namespace FluxoCaixa.Business
{
    public interface ILancamentoBusiness
    {
        Task<IEnumerable<Lancamento>> GetAllLancamentosAsync();
        Task<Lancamento> AddLancamentoAsync(Lancamento lancamento);
        Task<IEnumerable<ConsolidadoDiario>> GetConsolidadoDiarioAsync();
    }
}
