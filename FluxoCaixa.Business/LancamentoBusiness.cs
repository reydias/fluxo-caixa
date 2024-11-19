using FluxoCaixa.Data;
using FluxoCaixa.Domain;

namespace FluxoCaixa.Business
{
    public class LancamentoBusiness : ILancamentoBusiness
    {
        private readonly LancamentoRepository _repository;

        public LancamentoBusiness(LancamentoRepository repository)
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

        public async Task<IEnumerable<ConsolidadoDiario>> GetConsolidadoDiarioAsync()
            => await _repository.GetConsolidadoDiarioAsync();
    }
}
