
namespace EvolucaoTestes.IRPF.Tests
{
    public class IRPFTest
    {
        [Theory(DisplayName = "Deve calcular desconto correto")]
        [InlineData(1903.99, 0)]
        [InlineData(2826.65, 69.19875)]
        [InlineData(3751.05, 207.8575)]
        [InlineData(4664.68, 413.42300)]
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
