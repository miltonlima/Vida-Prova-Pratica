using Microsoft.Extensions.Logging;
using SistemaCompra.Application.SolicitacaoCompra.Notification;
using System.Threading.Tasks;

namespace SistemaCompra.API.Notification
{
    public class FornecedorNotifierService : IFornecedorNotifierService
    {
        private readonly ILogger<FornecedorNotifierService> _logger;

        public FornecedorNotifierService(ILogger<FornecedorNotifierService> logger)
        {
            _logger = logger;
        }

        public Task NotificarCompraEfetivada(string nomeFornecedor, string usuarioSolicitante)
        {
            _logger.LogInformation("Fornecedor {NomeFornecedor} notificado sobre a compra efetivada pelo usuário {UsuarioSolicitante}.", nomeFornecedor, usuarioSolicitante);
            return Task.CompletedTask;
        }
    }
}