class Program
{
    static List<Funcionario> funcionarios = new List<Funcionario>();

    static void Main(string[] args)
    {
        funcionarios.Add(new FuncionarioLanche("Ana", "123456789", "1234567", "ana@cinema.com", 19, "999999999", "Feminino", "Atendente"));
        funcionarios.Add(new FuncionarioCaixa("Pedro", "987654321", "7654321", "pedro@cinema.com", 18, "988888888", "Masculino", DateTime.Now, "08:00", "18:00", 1000.0, 950.0, 1));
        MostrarFuncionarios();
        ExibirMenu();

        while (true)
        {
           
            int opcao;
            if (int.TryParse(Console.ReadLine(), out opcao))
            {

                switch (opcao)
                {
                    case 1:
                        AdicionarFuncionario();
                        break;
                    case 2:
                        RemoverFuncionario();
                        break;
                    case 3:
                        AtualizarFuncionario();
                        break;
                    case 4:
                        ProcurarFuncionario();
                        break;
                    case 5:
                        AtualizarCargoFuncionario();
                        break;
                    case 6:
                        PromoverFuncionario();
                        break;
                    case 7:
                        CalcularDiferencaSaldo();
                        break;
                    case 8:
                        VerificarStatusCaixa();
                        break;
                    case 9:
                        ExibirDadosCaixa();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
    }

    static void MostrarFuncionarios()
    {
        Console.WriteLine("Lista de Funcionários Cadastrados:");
        foreach (var func in funcionarios)
        {
            func.VisualizarFuncionario();
        }
        Console.WriteLine();
    }

    static void ExibirMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Adicionar novo funcionário");
        Console.WriteLine("2 - Remover funcionário");
        Console.WriteLine("3 - Atualizar dados de um funcionário");
        Console.WriteLine("4 - Procurar funcionário");
        Console.WriteLine("5 - Atualizar cargo do funcionário");
        Console.WriteLine("6 - Promover funcionário");
        Console.WriteLine("7 - Calcular diferença de saldo");
        Console.WriteLine("8 - Verificar status do caixa");
        Console.WriteLine("9 - Exibir dados do caixa");
        Console.WriteLine("0 - Sair");
    }

    static void AdicionarFuncionario()
    {
        Console.WriteLine("Digite os dados do novo funcionário:");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("CPF: ");
        string cpf = Console.ReadLine();
        Console.Write("RG: ");
        string rg = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Idade: ");
        int idade = int.Parse(Console.ReadLine());
        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();
        Console.Write("Sexo: ");
        string sexo = Console.ReadLine();
        Console.Write("Cargo: ");
        string cargo = Console.ReadLine();

        Funcionario novoFuncionario = new FuncionarioLanche(nome, cpf, rg, email, idade, telefone, sexo, cargo);
        funcionarios.Add(novoFuncionario); 
        Console.WriteLine("Funcionário adicionado com sucesso!");
        ExibirMenu();
    }

    static void RemoverFuncionario()
    {
        Console.Write("Digite o CPF do funcionário para remover: ");
        string cpf = Console.ReadLine();
        Funcionario func = funcionarios.Find(f => f.CPF == cpf);

        if (func != null)
        {
            funcionarios.Remove(func);
            Console.WriteLine("Funcionário removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado.");
        }
        ExibirMenu();
    }

    static void AtualizarFuncionario()
    {
        Console.Write("Digite o CPF do funcionário para atualizar: ");
        string cpf = Console.ReadLine();
        Funcionario func = funcionarios.Find(f => f.CPF == cpf);

        if (func != null)
        {
            Console.WriteLine("Digite os novos dados:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Sexo: ");
            string sexo = Console.ReadLine();

            func.Nome = nome;
            func.Email = email;
            func.Telefone = telefone;
            func.Sexo = sexo;
            Console.WriteLine("Dados do funcionário atualizados com sucesso!");
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado.");
        }
        ExibirMenu();
    }

    static void ProcurarFuncionario()
    {
        Console.Write("Digite o CPF do funcionário para procurar: ");
        string cpf = Console.ReadLine();
        Funcionario func = funcionarios.Find(f => f.CPF == cpf);

        if (func != null)
        {
            func.VisualizarFuncionario();
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado.");
        }
        ExibirMenu();
    }

    static void AtualizarCargoFuncionario()
    {
        Console.Write("Digite o CPF do funcionário para atualizar o cargo: ");
        string cpf = Console.ReadLine();
        Funcionario func = funcionarios.Find(f => f.CPF == cpf);

        if (func != null && func is FuncionarioLanche funcionarioLanche)
        {
            Console.Write("Digite o novo cargo: ");
            string novoCargo = Console.ReadLine();
            funcionarioLanche.AtualizarCargo(novoCargo);
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado ou não é um funcionário da lanchonete.");
        }
        ExibirMenu();
    }

    static void PromoverFuncionario()
    {
        Console.Write("Digite o CPF do funcionário para promover: ");
        string cpf = Console.ReadLine();
        Funcionario func = funcionarios.Find(f => f.CPF == cpf);

        if (func != null && func is FuncionarioLanche funcionarioLanche)
        {
            funcionarioLanche.PromoverFuncionario();
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado ou não é um funcionário da lanchonete.");
        }
        ExibirMenu();
    }

    static void CalcularDiferencaSaldo()
    {
        Console.Write("Digite o CPF do funcionário para calcular a diferença de saldo: ");
        string cpf = Console.ReadLine();
        Funcionario func = funcionarios.Find(f => f.CPF == cpf);

        if (func != null && func is FuncionarioCaixa funcionarioCaixa)
        {
            double diferenca = funcionarioCaixa.CalcularDiferencaSaldo();
            Console.WriteLine($"Diferença de saldo: {diferenca}");
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado ou não é um funcionário caixa.");
        }
        ExibirMenu();
    }

    static void VerificarStatusCaixa()
    {
        Console.Write("Digite o CPF do funcionário para verificar o status do caixa: ");
        string cpf = Console.ReadLine();
        Funcionario func = funcionarios.Find(f => f.CPF == cpf);

        if (func != null && func is FuncionarioCaixa funcionarioCaixa)
        {
            string status = funcionarioCaixa.VerificarStatusCaixa();
            Console.WriteLine(status);
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado ou não é um funcionário caixa.");
        }
        ExibirMenu();
    }

    static void ExibirDadosCaixa()
    {
        Console.Write("Digite o CPF do funcionário para exibir os dados do caixa: ");
        string cpf = Console.ReadLine();
        Funcionario func = funcionarios.Find(f => f.CPF == cpf);

        if (func != null && func is FuncionarioCaixa funcionarioCaixa)
        {
            funcionarioCaixa.ExibirDadosCaixa();
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado ou não é um funcionário caixa.");
        }
        ExibirMenu();
    }
}
