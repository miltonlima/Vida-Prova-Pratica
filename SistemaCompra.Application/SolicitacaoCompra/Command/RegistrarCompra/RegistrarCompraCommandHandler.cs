using MediatR;
using SistemaCompra.Application.SolicitacaoCompra.Notification;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : IRequestHandler<RegistrarCompraCommand>
    {
        private readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;
        private readonly IEmailClienteService _emailClienteService;
        private readonly IFornecedorNotifierService _fornecedorNotifierService;

        public RegistrarCompraCommandHandler(
            ISolicitacaoCompraRepository solicitacaoCompraRepository,
            IEmailClienteService emailClienteService,
            IFornecedorNotifierService fornecedorNotifierService)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
            _emailClienteService = emailClienteService;
            _fornecedorNotifierService = fornecedorNotifierService;
        }

        async Task<Unit> IRequestHandler<RegistrarCompraCommand, Unit>.Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = new Domain.SolicitacaoCompraAggregate.SolicitacaoCompra(
                request.UsuarioSolicitante,
                request.NomeFornecedor
            );

            await _solicitacaoCompraRepository.RegistrarCompra(solicitacaoCompra);
            await _emailClienteService.EnviarCompraEfetivada(request.UsuarioSolicitante, request.NomeFornecedor);
            await _fornecedorNotifierService.NotificarCompraEfetivada(request.NomeFornecedor, request.UsuarioSolicitante);

            return Unit.Value;
        }
    }
}