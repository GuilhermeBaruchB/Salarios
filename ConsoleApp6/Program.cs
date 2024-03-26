using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Funcionario> funcionarios = new List<Funcionario>();

        while (true)
        {
            Console.WriteLine("Escolha o tipo de funcionário a ser cadastrado:");
            Console.WriteLine("1 - Assalariado");
            Console.WriteLine("2 - Comissionado");
            Console.WriteLine("3 - Horista");
            Console.WriteLine("4 - Encerrar cadastro");

            int opcao = Convert.ToInt32(Console.ReadLine());

            if (opcao == 4)
            {
                break;
            }

            Funcionario funcionario;

            switch (opcao)
            {
                case 1:
                    funcionario = CadastrarAssalariado();
                    break;
                case 2:
                    funcionario = CadastrarComissionado();
                    break;
                case 3:
                    funcionario = CadastrarHorista();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    continue;
            }

            funcionarios.Add(funcionario);
        }

        double totalFolha = 0;
        int quantidadeFuncionarios = funcionarios.Count;
        double somaSalarios = 0;

        Console.WriteLine("\nLista de funcionários cadastrados:");

        foreach (var funcionario in funcionarios)
        {
            double salario = funcionario.CalcularSalario();
            totalFolha += salario;
            somaSalarios += salario;
            Console.WriteLine(funcionario);
        }

        double mediaSalarial = somaSalarios / quantidadeFuncionarios;

        Console.WriteLine($"\nTotal da folha de pagamento: R$ {totalFolha:F2}");
        Console.WriteLine($"Quantidade de funcionários cadastrados: {quantidadeFuncionarios}");
        Console.WriteLine($"Média salarial da empresa: R$ {mediaSalarial:F2}");
    
        Console.ReadKey();
    }

    static Funcionario CadastrarAssalariado()
    {
        Console.Write("Nome do funcionário: ");
        string nome = Console.ReadLine();
        Console.Write("Salário fixo: R$ ");
        double salarioFixo = Convert.ToDouble(Console.ReadLine());
        Console.Write("Descontos: R$ ");
        double descontos = Convert.ToDouble(Console.ReadLine());

        return new Assalariado(nome, salarioFixo, descontos);
    }

    static Funcionario CadastrarComissionado()
    {
        Console.Write("Nome do funcionário: ");
        string nome = Console.ReadLine();
        Console.Write("Percentual de comissão (%): ");
        double percentualComissao = Convert.ToDouble(Console.ReadLine());
        Console.Write("Total de vendas: R$ ");
        double totalVendas = Convert.ToDouble(Console.ReadLine());

        return new Comissionado(nome, percentualComissao, totalVendas);
    }

    static Funcionario CadastrarHorista()
    {
        Console.Write("Nome do funcionário: ");
        string nome = Console.ReadLine();
        Console.Write("Valor da hora: R$ ");
        double valorHora = Convert.ToDouble(Console.ReadLine());
        Console.Write("Horas trabalhadas: ");
        int horasTrabalhadas = Convert.ToInt32(Console.ReadLine());

        return new Horista(nome, valorHora, horasTrabalhadas);
    }
}

abstract class Funcionario
{
    protected string nome;

    public Funcionario(string nome)
    {
        this.nome = nome;
    }

    public abstract double CalcularSalario();

    public override string ToString()
    {
        return $"Nome: {nome}, Salário: R$ {CalcularSalario():F2}";
    }
}

class Assalariado : Funcionario
{
    private double salarioFixo;
    private double descontos;

    public Assalariado(string nome, double salarioFixo, double descontos) : base(nome)
    {
        this.salarioFixo = salarioFixo;
        this.descontos = descontos;
    }

    public override double CalcularSalario()
    {
        return salarioFixo - descontos;
    }
} 

class Comissionado : Funcionario
{
    private double percentualComissao;
    private double totalVendas;

    public Comissionado(string nome, double percentualComissao, double totalVendas) : base(nome)
    {
        this.percentualComissao = percentualComissao;
        this.totalVendas = totalVendas;
    }

    public override double CalcularSalario()
    {
        return (percentualComissao / 100) * totalVendas;
    }
}

class Horista : Funcionario
{
    private double valorHora;
    private int horasTrabalhadas;

    public Horista(string nome, double valorHora, int horasTrabalhadas) : base(nome)
    {
        this.valorHora = valorHora;
        this.horasTrabalhadas = horasTrabalhadas;
    }

    public override double CalcularSalario()
    {
        return valorHora * horasTrabalhadas;
    }
    
}