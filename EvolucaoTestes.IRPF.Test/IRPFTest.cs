
namespace EvolucaoTestes.IRPF.Tests
{
    public class IRPFTest
    {
        [Theory(DisplayName = "Deve calcular desconto correto")]
        [InlineData(1903.99, 0)]
        [InlineData(2826.65, 142.80)]
        [InlineData(3751.05, 354.80)]
        [InlineData(4664.68, 636.13)]
        public void CalcularImposto_SucessTest(decimal salarioBruto, decimal descontoEsperado)
        {
            decimal descontoCalculado = IRPF.CalcularDesconto(salarioBruto);

            Assert.Equal(descontoEsperado, descontoCalculado);
        }

        [Fact(DisplayName = "Deve falhar ao calcular o desconto incorreto")]
        public void CalcularImposto_FailTest()
        {
            decimal salarioBruto = 2826.65m;
            decimal descontoCalculado = IRPF.CalcularDesconto(salarioBruto);

            Assert.NotEqual(100.80m, descontoCalculado);
        }
    }
}
