using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infra.Testes
{
    public class ClienteRepositoriosTestes
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteRepositoriosTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IClienteRepositorio>();
        }

        [Fact]
        public void TestaObterTodosClientes()
        {
            List<Cliente> lista = _repositorio.ObterTodos();

            Assert.NotNull(lista);
            Assert.Equal(3, lista.Count);
        }

        [Fact]
        public void ObterClientePorId()
        {
            Cliente cliente = _repositorio.ObterPorId(1);

            Assert.NotNull(cliente);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ObterClientePorVariosIds(int id)
        {
            Cliente cliente = _repositorio.ObterPorId(id);

            Assert.NotNull(cliente);
        }
    }
}
