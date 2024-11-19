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

        public async Task<Lancamento> AddLancamento(LancamentoInput input)
        {
            var novoLancamento = new Lancamento
            {
                Id = Guid.NewGuid(),
                Tipo = input.Tipo,
                Valor = input.Valor,
                Data = input.Data,
                Descricao = input.Descricao
            };
            return await _lancamentoBusiness.AddLancamentoAsync(novoLancamento);
        }
    }
}
