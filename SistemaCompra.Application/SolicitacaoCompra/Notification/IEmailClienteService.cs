using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Notification
{
    public interface IEmailClienteService
    {
        Task EnviarCompraEfetivada(string usuarioSolicitante, string nomeFornecedor);
    }
}