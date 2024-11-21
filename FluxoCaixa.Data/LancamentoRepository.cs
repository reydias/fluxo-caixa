using Microsoft.EntityFrameworkCore;
using FluxoCaixa.Domain;
using FluxoCaixa.Api;


namespace FluxoCaixa.Data
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public LancamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lancamento>> GetAllAsync()
            => await _context.Lancamentos.AsNoTracking().ToListAsync();

        public async Task AddAsync(Lancamento lancamento)
        {
            await _context.Lancamentos.AddAsync(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task<Lancamento> GetByIdAsync(Guid id)
        {
            var lancamento = await _context.Lancamentos
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id);

            if (lancamento == null)
                throw new KeyNotFoundException($"Lançamento com Id {id} não encontrado.");

            return lancamento;
        }


        public async Task RemoveAsync(Lancamento lancamento)
        {
            _context.Lancamentos.Remove(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ConsolidadoDiario>> GetConsolidadoDiarioAsync()
        {
            return await _context.Lancamentos
                .GroupBy(l => l.Data.Date)
                .Select(g => new ConsolidadoDiario
                {
                    Data = g.Key,
                    Saldo = g.Sum(l => l.Tipo == "C" ? l.Valor : -l.Valor)
                })
                .AsNoTracking().ToListAsync();
        }
    }

}
