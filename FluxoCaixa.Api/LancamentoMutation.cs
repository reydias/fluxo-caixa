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
            if(input.Tipo != "C" && input.Tipo != "D")
            {
                throw new ArgumentException("O tipo deve ser 'C' para Crédito ou 'D' para Débito.");
            }
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

        public async Task<Lancamento> RemoveLancamento(Guid id)
        {
            return await _lancamentoBusiness.RemoveLancamentoAsync(id);
        }
    }
}
