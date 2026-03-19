using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Notification
{
    public interface IFornecedorNotifierService
    {
        Task NotificarCompraEfetivada(string nomeFornecedor, string usuarioSolicitante);
    }
}