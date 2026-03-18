namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoCompraRepository
    {
        System.Threading.Tasks.Task RegistrarCompraAsync(SolicitacaoCompra solicitacaoCompra);
    }
}
