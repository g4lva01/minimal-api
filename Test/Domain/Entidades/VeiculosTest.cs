using MinimalApi.Dominio.Entidades;
namespace Test.Domain.Entidades
{
    [TestClass]
    public class VeiculosTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Veiculo veiculo = new()
            {
                Ano = 2001,
                Id = 1,
                Marca = "Toyota",
                Nome = "Corola"
            };
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("Toyota", veiculo.Marca);
            Assert.AreEqual("Corola", veiculo.Nome);
            Assert.AreEqual(2001, veiculo.Ano);
        }
    }
}