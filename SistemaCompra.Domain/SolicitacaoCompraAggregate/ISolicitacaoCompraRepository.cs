namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoCompraRepository
    {
        System.Threading.Tasks.Task RegistrarCompra(SolicitacaoCompra solicitacaoCompra);
    }
}
