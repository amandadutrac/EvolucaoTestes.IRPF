namespace EvolucaoTestes.IRPF
{
    public class IRPFTest
    {
        [Theory(DisplayName = "Deve calcular desconto correto")]
        [InlineData(1903.99, 0)]           
        [InlineData(2500.00, 142.80)]      
        [InlineData(3500.00, 354.80)]      
        [InlineData(4500.00, 636.13)]     
        [InlineData(5000.00, 869.36)]      
        public void CalcularImposto_SucessTest(decimal salarioBruto, decimal descontoEsperado)
        {
            decimal descontoCalculado = IRPF.CalcularDesconto(salarioBruto);

            Assert.Equal(descontoEsperado, descontoCalculado);
        }

        [Fact]
        public void CalcularImposto_FailTest()
        {
            decimal salarioBruto = 3000.00m; 
            decimal descontoCalculado = IRPF.CalcularDesconto(salarioBruto);

            Assert.NotEqual(100.00m, descontoCalculado); 
        }
    }
}
