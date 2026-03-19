using Microsoft.Extensions.Logging;
using SistemaCompra.Application.SolicitacaoCompra.Notification;
using System.Threading.Tasks;

namespace SistemaCompra.API.Notification
{
    public class EmailClienteService : IEmailClienteService
    {
        private readonly ILogger<EmailClienteService> _logger;

        public EmailClienteService(ILogger<EmailClienteService> logger)
        {
            _logger = logger;
        }

        public Task EnviarCompraEfetivada(string usuarioSolicitante, string nomeFornecedor)
        {
            _logger.LogInformation("E-mail enviado para o cliente {UsuarioSolicitante} sobre a compra com fornecedor {NomeFornecedor}.", usuarioSolicitante, nomeFornecedor);
            return Task.CompletedTask;
        }
    }
}