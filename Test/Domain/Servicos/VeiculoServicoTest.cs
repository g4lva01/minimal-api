using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class VeiculoServicoTest
    {
        private static DbContexto CriarContextoDeTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));
            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            var configuration = builder.Build();
            return new DbContexto(configuration);
        }
        private VeiculoServico servico  =  new(CriarContextoDeTeste());
        [TestMethod]
        public void TestIncluir(){
            Veiculo veiculo = new()
            {                
                Ano = 2001,
                Id = 1,
                Marca = "Toyota",
                Nome = "Corola"
            };
            servico.Incluir(veiculo);
            Assert.AreEqual(1, servico.Todos(1).Count);
            servico.Apagar(veiculo);
        }
        [TestMethod]
        public void TestApagar(){
            Veiculo veiculo = new()
            {                
                Ano = 2001,
                Id = 2,
                Marca = "Toyota",
                Nome = "Corola"
            };
            servico.Incluir(veiculo);
            servico.Apagar(veiculo);
            Assert.AreEqual(1, servico.Todos(1).Count);

        }
        [TestMethod]
        public void TestAtualizar(){
            Veiculo veiculo = new()
            {                
                Ano = 2024,
                Id = 1,
                Marca = "Renaut",
                Nome = "Qwid"
            };
            servico.Atualizar(veiculo);
            Assert.AreEqual(2024, veiculo.Ano);
            Assert.AreEqual("Renaut", veiculo.Marca);
            Assert.AreEqual("Qwid", veiculo.Nome);


        }
        [TestMethod]
        public void TestBuscaPorId(){
            Veiculo veiculo = new()
            {                
                Ano = 2024,
                Id = 4,
                Marca = "GTR",
                Nome = "Porshe"
            };
            servico.Incluir(veiculo);
            Veiculo? veiculoDoBanco = servico.BuscaPorId(veiculo.Id);
            Assert.AreEqual(4, veiculoDoBanco?.Id);
        }
    }
}