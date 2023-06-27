using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
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
        [Fact]
        public void TestaObterTodosClientes()
        {
            var _repositorio = new ClienteRepositorio();

            List<Cliente> lista = _repositorio.ObterTodos();

            Assert.NotNull(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}
