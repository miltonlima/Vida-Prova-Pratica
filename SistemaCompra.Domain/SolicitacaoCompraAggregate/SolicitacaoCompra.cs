using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }
        public Situacao Situacao { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Itens = new List<Item>();
            Data = DateTime.Now;
            TotalGeral = new Money();
            CondicaoPagamento = new CondicaoPagamento(0);
            Situacao = Situacao.Solicitado;
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            var itensCompra = new List<Item>(itens ?? Enumerable.Empty<Item>());

            if (!itensCompra.Any())
                throw new BusinessRuleException("O total de itens de compra deve ser maior que 0.");

            Itens = itensCompra;

            var totalGeral = new Money();
            foreach (var item in Itens)
            {
                totalGeral = totalGeral.Add(item.Subtotal);
            }

            TotalGeral = totalGeral;
            CondicaoPagamento = TotalGeral.Value > 50000
                ? new CondicaoPagamento(30)
                : new CondicaoPagamento(0);
        }
    }
}
