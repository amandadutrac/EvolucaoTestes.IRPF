﻿namespace EvolucaoTestes.IRPF
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroContribuintes = validarDadosEntrada();
            processarDadosContribuintes(numeroContribuintes);
        }

        static int validarDadosEntrada()
        {
            Console.Write("Informe o número de contribuintes a calcular: ");
            if (int.TryParse(Console.ReadLine(), out int numeroContribuinte) && numeroContribuinte > 0)
            {
                return numeroContribuinte;
            }
            else
            {
                Console.WriteLine("Por favor, informe um valor válido para o número de contribuintes.");
                return validarDadosEntrada();
            }
        }

        static void processarDadosContribuintes(int numeroContribuintes)
        {
            for (int i = 0; i < numeroContribuintes; i++)
            {
                Console.WriteLine($"\nContribuinte {i + 1}");
                Console.Write("Informe o nome do contribuinte: ");
                string nomeContribuinte = Console.ReadLine() ?? "Desconhecido";

                decimal salarioBruto = validarSalarioEntrada();

                decimal desconto = calcularDesconto(salarioBruto);
                decimal salarioLiquido = salarioBruto - desconto;

                exibirResultados(nomeContribuinte, salarioBruto, desconto, salarioLiquido);
            }
        }

        static decimal validarSalarioEntrada()
        {
            Console.Write("Informe um valor válido para salário: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal salarioBruto) && salarioBruto >= 0)
            {
                return salarioBruto;
            }
            else
            {
                Console.WriteLine("Por favor, informe um valor válido para salário.");
                return validarSalarioEntrada();
            }
        }

        static decimal calcularDesconto(decimal salarioBruto)
        {
            decimal aliquota;
            decimal deducao;

            if (salarioBruto <= 1903.99m)
            {
                aliquota = 0m;
                deducao = 0m;
            }
            else if (salarioBruto <= 2826.65m)
            {
                aliquota = 0.075m;
                deducao = 142.80m;
            }
            else if (salarioBruto <= 3751.05m)
            {
                aliquota = 0.15m;
                deducao = 354.80m;
            }
            else if (salarioBruto <= 4664.68m)
            {
                aliquota = 0.225m;
                deducao = 636.13m;
            }
            else
            {
                aliquota = 0.275m;
                deducao = 869.36m;
            }

            return salarioBruto * aliquota - deducao;
        }

        static void exibirResultados(string nome, decimal salarioBruto, decimal desconto, decimal salarioLiquido)
        {
            Console.WriteLine($"Nome do Contribuinte: {nome}");
            Console.WriteLine($"Salário Bruto: R$ {salarioBruto:F2}");
            Console.WriteLine($"Desconto: R$ {desconto:F2}");
            Console.WriteLine($"Salário Líquido: R$ {salarioLiquido:F2}");
        }
    }
}
