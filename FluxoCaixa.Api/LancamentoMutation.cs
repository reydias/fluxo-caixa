using FluxoCaixa.Business;
using FluxoCaixa.Domain;

namespace FluxoCaixa.Api
{
    public class LancamentoMutation
    {
        private readonly ILancamentoBusiness _lancamentoBusiness;

        public LancamentoMutation(ILancamentoBusiness lancamentoBusiness)
        {
            _lancamentoBusiness = lancamentoBusiness;
        }

        public async Task<Lancamento> AddLancamento(Lancamento input)
        {
            return await _lancamentoBusiness.AddLancamentoAsync(input);
        }
    }
}
