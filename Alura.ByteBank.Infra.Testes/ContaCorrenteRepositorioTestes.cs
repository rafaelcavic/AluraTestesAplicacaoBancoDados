using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Alura.ByteBank.Infra.Testes
{
    public class ContaCorrenteRepositorioTestes
    {
        private readonly IContaCorrenteRepositorio _repositorio;

        public ContaCorrenteRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IContaCorrenteRepositorio>();
        }

        [Fact]
        public void TestaAtualizaSaldoDeterminadaConta()
        {
            var conta = _repositorio.ObterPorId(1);
            double saldoNovo = 15;
            conta.Saldo = saldoNovo;

            var atualizado = _repositorio.Atualizar(1, conta);

            Assert.True(atualizado);
        }

        [Fact]
        public void TestaInsereNovaContaNoBancoDados()
        {
            var conta = new ContaCorrente()
            {
                Saldo = 10,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Nome = "Clark Johnson",
                    CPF = "486.074.980-45",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Agrônomo",
                    Id = 1
                },
                Agencia = new Agencia()
                {
                    Nome = "Agencia Nacional West Coast",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Rua das Oliveiras, 1234",
                    Numero = 145
                }
            };

            var retorno = _repositorio.Adicionar(conta);

            Assert.True(retorno);
        }

    }
}
