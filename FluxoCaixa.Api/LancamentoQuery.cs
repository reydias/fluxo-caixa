using FluxoCaixa.Business;
using FluxoCaixa.Domain;

namespace FluxoCaixa.Api
{
    public class LancamentoQuery
    {
        private readonly ILancamentoBusiness _lancamentoBusiness;

        public LancamentoQuery(ILancamentoBusiness lancamentoBusiness)
        {
            _lancamentoBusiness = lancamentoBusiness;
        }

        public async Task<IEnumerable<Lancamento>> GetLancamentos()
            => await _lancamentoBusiness.GetAllLancamentosAsync();

        public async Task<IEnumerable<ConsolidadoDiario>> GetConsolidadoDiario()
            => await _lancamentoBusiness.GetConsolidadoDiarioAsync();
    }
}
