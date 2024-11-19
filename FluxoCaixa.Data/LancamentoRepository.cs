using Microsoft.EntityFrameworkCore;
using FluxoCaixa.Domain;


namespace FluxoCaixa.Data
{
    public class LancamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public LancamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lancamento>> GetAllAsync()
            => await _context.Lancamentos.ToListAsync();

        public async Task AddAsync(Lancamento lancamento)
        {
            await _context.Lancamentos.AddAsync(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ConsolidadoDiario>> GetConsolidadoDiarioAsync()
        {
            return await _context.Lancamentos
                .GroupBy(l => l.Data.Date)
                .Select(g => new ConsolidadoDiario
                {
                    Data = g.Key,
                    Saldo = g.Sum(l => l.Tipo == "crédito" ? l.Valor : -l.Valor)
                })
                .ToListAsync();
        }
    }

}
