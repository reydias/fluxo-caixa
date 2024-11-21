using FluxoCaixa.Business;
using FluxoCaixa.Data;
using FluxoCaixa.Domain;
using Moq;

namespace UnitTest
{
    public class LancamentoBusinessTests
    {
        private readonly Mock<ILancamentoRepository> _mockRepository;
        private readonly LancamentoBusiness _business;

        public LancamentoBusinessTests()
        {
            _mockRepository = new Mock<ILancamentoRepository>();
            _business = new LancamentoBusiness(_mockRepository.Object);
        }

        [Fact]
        public async Task GetConsolidadoDiarioAsync_ShouldReturnConsolidatedData()
        {
            // Arrange
            var expectedData = new List<ConsolidadoDiario>
        {
            new ConsolidadoDiario { Data = DateTime.Today, Saldo = 100.00m }
        };
            _mockRepository.Setup(r => r.GetConsolidadoDiarioAsync())
                .ReturnsAsync(expectedData);

            // Act
            var result = await _business.GetConsolidadoDiarioAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Count());
            Assert.Equal(100.00m, result.First().Saldo);
        }

        [Fact]
        public async Task AddLancamentoAsync_ShouldCallRepositoryOnce()
        {
            // Arrange
            var lancamento = new Lancamento
            {
                Id = Guid.NewGuid(),
                Tipo = "C",
                Valor = 50.00m,
                Data = DateTime.Now
            };

            _mockRepository
                .Setup(r => r.AddAsync(lancamento))
                .Returns(Task.CompletedTask);

            // Act
            await _business.AddLancamentoAsync(lancamento);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(lancamento), Times.Once);
        }

        [Fact]
        public async Task GetLancamentoByIdAsync_ShouldReturnCorrectLancamento()
        {
            // Arrange
            var lancamentoId = Guid.NewGuid();
            var expectedLancamento = new Lancamento
            {
                Id = lancamentoId,
                Tipo = "C",
                Valor = 100.00m,
                Data = DateTime.Today
            };

            _mockRepository
                .Setup(r => r.GetByIdAsync(lancamentoId))
                .ReturnsAsync(expectedLancamento);

            // Act
            var result = await _business.GetLancamentoByIdAsync(lancamentoId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(lancamentoId, result.Id);
            Assert.Equal("C", result.Tipo);
            Assert.Equal(100.00m, result.Valor);
        }

        [Fact]
        public async Task RemoveLancamentoAsync_ShouldCallRepositoryOnce()
        {
            // Arrange
            var lancamentoId = Guid.NewGuid();
            var lancamento = new Lancamento
            {
                Id = lancamentoId
            };

            _mockRepository
                .Setup(r => r.GetByIdAsync(lancamentoId))
                .ReturnsAsync(lancamento);
            
            _mockRepository
                .Setup(r => r.RemoveAsync(It.IsAny<Lancamento>()))
                .Returns(Task.CompletedTask);

            // Act
            await _business.RemoveLancamentoAsync(lancamentoId);

            // Assert
            _mockRepository.Verify(r => r.GetByIdAsync(lancamentoId), Times.Once);
            _mockRepository.Verify(r => r.RemoveAsync(lancamento), Times.Once);
        }

        [Fact]
        public async Task RemoveLancamentoAsync_ShouldThrowException_WhenLancamentoNotFound()
        {
            // Arrange
            var lancamentoId = Guid.NewGuid();
            var lancamento = new Lancamento
            {
                Id = lancamentoId
            };
            _mockRepository
                .Setup(r => r.RemoveAsync(lancamento))
                .ThrowsAsync(new KeyNotFoundException("Lancamento not found"));

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _business.RemoveLancamentoAsync(lancamentoId));
        }

    }
}
