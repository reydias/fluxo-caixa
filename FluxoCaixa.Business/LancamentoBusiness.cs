using FluxoCaixa.Data;
using FluxoCaixa.Domain;

namespace FluxoCaixa.Business
{
    public class LancamentoBusiness : ILancamentoBusiness
    {
        private readonly ILancamentoRepository _repository;

        public LancamentoBusiness(ILancamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Lancamento>> GetAllLancamentosAsync()
            => await _repository.GetAllAsync();

        public async Task<Lancamento> AddLancamentoAsync(Lancamento lancamento)
        {
            if (lancamento.Id == Guid.Empty)
            {
                lancamento.Id = Guid.NewGuid();
            }
            await _repository.AddAsync(lancamento);
            return lancamento;
        }

        public async Task<Lancamento> RemoveLancamentoAsync(Guid lancamentoId)
        {
            var lancamento = await _repository.GetByIdAsync(lancamentoId);
            if (lancamento == null)
            {
                throw new KeyNotFoundException("Lançamento not found.");
            }

            await _repository.RemoveAsync(lancamento);
            return lancamento;
        }

        public async Task<IEnumerable<ConsolidadoDiario>> GetConsolidadoDiarioAsync()
            => await _repository.GetConsolidadoDiarioAsync();

        public async Task<Lancamento> GetLancamentoByIdAsync(Guid lancamentoId)
        {
            return await _repository.GetByIdAsync(lancamentoId);
        }
    }
}
