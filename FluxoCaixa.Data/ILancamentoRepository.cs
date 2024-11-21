using FluxoCaixa.Domain;

namespace FluxoCaixa.Data
{
    public interface ILancamentoRepository
    {
        Task<IEnumerable<Lancamento>> GetAllAsync();
        Task AddAsync(Lancamento lancamento);
        Task<Lancamento> GetByIdAsync(Guid id);
        Task<IEnumerable<ConsolidadoDiario>> GetConsolidadoDiarioAsync();
        Task RemoveAsync(Lancamento lancamento);
    }
}