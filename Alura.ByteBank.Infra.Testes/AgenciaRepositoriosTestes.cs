using Alura.ByteBank.Dados.Repositorio;
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
    public class AgenciaRepositoriosTestes
    {
        private IAgenciaRepositorio _repositorio;

        public AgenciaRepositoriosTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IAgenciaRepositorio>();
        }

        [Fact]
        public void RemoverAgencia()
        {
            var atualizado = _repositorio.Excluir(1);

            Assert.True(atualizado);
        }

        [Fact]
        public void TestaExcecaoConsultaPorAgenciaPorId()
        {
            Assert.Throws<Exception>(() => _repositorio.ObterPorId(12));
        }
    }
}
