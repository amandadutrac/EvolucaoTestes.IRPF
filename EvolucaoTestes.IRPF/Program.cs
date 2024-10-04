namespace EvolucaoTestes.IRPF
{
    class Program
    {
        public static void Main()
        {
            int numeroContribuintes = IRPF.ValidarDadosEntrada();
            IRPF.ProcessarDadosContribuintes(numeroContribuintes);
        }

    }
}
