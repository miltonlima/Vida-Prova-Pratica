using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : IRequestHandler<RegistrarCompraCommand>
    {
        private readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;

        public RegistrarCompraCommandHandler(ISolicitacaoCompraRepository solicitacaoCompraRepository)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
        }

        async Task<Unit> IRequestHandler<RegistrarCompraCommand, Unit>.Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = new Domain.SolicitacaoCompraAggregate.SolicitacaoCompra(
                request.UsuarioSolicitante,
                request.NomeFornecedor
            );

            await _solicitacaoCompraRepository.RegistrarCompraAsync(solicitacaoCompra);

            return Unit.Value;
        }
    }
}