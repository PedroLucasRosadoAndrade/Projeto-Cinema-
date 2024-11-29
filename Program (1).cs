using System;
using System.Collections.Generic;

class Program
{
    static List<Produto> produtos = new List<Produto>();  
    static List<Estoque> estoques = new List<Estoque>();  
    static List<Funcionario> funcionarios = new List<Funcionario>();

    static void Main(string[] args)
    {
        Produto cachorroQuente = new Produto("pipoca", DateTime.Now.AddMonths(6), "Lanche", "Lanchonete X", 50, 15.0);
        Estoque estoqueCachorroQuente = new Estoque("pipoca", DateTime.Now.AddMonths(6), "Lanche", "Lanchonete X", 50, 15.0, 100, 500);
        funcionarios.Add(new FuncionarioLanche("Ana", "123456789", "1234567", "ana@cinema.com", 19, "999999999", "Feminino", "Atendente"));
        funcionarios.Add(new FuncionarioCaixa("Pedro", "987654321", "7654321", "pedro@cinema.com", 18, "988888888", "Masculino", DateTime.Now, "08:00", "18:00", 1000.0, 950.0, 1));

        produtos.Add(cachorroQuente);
        estoques.Add(estoqueCachorroQuente);

        ExibirMenuModulo(); 
    }

    static void ExibirMenuModulo()
    {
        Console.WriteLine("\nEscolha o módulo que você deseja acessar:");
        Console.WriteLine("1 - Funcionário");
        Console.WriteLine("2 - Produto");
        Console.WriteLine("3 - Filme");
        Console.WriteLine("4 - Cliente");
        Console.WriteLine("0 - Sair");

        bool rodando = true;
        while (rodando)
        {
            int opcaoModulo;
            if (int.TryParse(Console.ReadLine(), out opcaoModulo))
            {
                switch (opcaoModulo)
                {
                    case 1:
                        MenuFuncionario(); 
                        break;
                    case 2:
                        MenuProduto();  
                        break;
                    case 3:
                        MenuFilme();  
                        break;
                    case 4:
                        MenuCliente();  
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        rodando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }

    static void MenuProduto()
    {
        bool voltarAoMenuPrincipal = false;

        while (!voltarAoMenuPrincipal)
        {
            Console.WriteLine("\nEscolha uma opção de produto:");
            Console.WriteLine("1 - Adicionar novo produto");
            Console.WriteLine("2 - Remover produto");
            Console.WriteLine("3 - Atualizar dados de produto");
            Console.WriteLine("4 - Exibir dados do produto");
            Console.WriteLine("5 - Verificar validade de produto");
            Console.WriteLine("6 - Gerenciar Estoque");
            Console.WriteLine("7 - Voltar ao menu principal");

            int opcao;
            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        AdicionarProduto();  
                        break;
                    case 2:
                        RemoverProduto();  
                        break;
                    case 3:
                        AtualizarProduto();  
                        break;
                    case 4:
                        ExibirProduto(); 
                        break;
                    case 5:
                        VerificarValidadeProduto(); 
                        break;
                    case 6:
                        GerenciarEstoque();  
                        break;
                    case 7:
                        voltarAoMenuPrincipal = true;
                        ExibirMenuModulo();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
    }

    static void AdicionarProduto()
    {
        Console.WriteLine("Digite o nome do produto:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite a data de validade (dd/MM/yyyy):");
        DateTime dataVali = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Digite o tipo do produto:");
        string tipo = Console.ReadLine();
        Console.WriteLine("Digite a marca do produto:");
        string marca = Console.ReadLine();
        Console.WriteLine("Digite a quantidade do produto:");
        int quantidade = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o valor do produto:");
        double valor = double.Parse(Console.ReadLine());

        Produto novoProduto = new Produto(nome, dataVali, tipo, marca, quantidade, valor);
        produtos.Add(novoProduto);
        Console.WriteLine("Produto adicionado com sucesso.");

        Console.WriteLine("Digite a capacidade máxima do estoque:");
        int capacidade = int.Parse(Console.ReadLine());

        Estoque novoEstoque = new Estoque(nome, dataVali, tipo, marca, quantidade, valor, quantidade, capacidade);
        estoques.Add(novoEstoque);
        Console.WriteLine("Estoque adicionado com sucesso.");
    }

    static void RemoverProduto()
    {
        Console.WriteLine("Digite o nome do produto para remover:");
        string nome = Console.ReadLine();
        Produto produto = produtos.Find(p => p.Nome == nome);
        if (produto != null)
        {
            produtos.Remove(produto);
            Console.WriteLine("Produto removido com sucesso.");

            Estoque estoque = estoques.Find(e => e.Nome == nome);
            if (estoque != null)
            {
                estoques.Remove(estoque);
                Console.WriteLine("Estoque removido com sucesso.");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    static void AtualizarProduto()
    {
        Console.WriteLine("Digite o nome do produto para atualizar:");
        string nome = Console.ReadLine();
        Produto produto = produtos.Find(p => p.Nome == nome);
        if (produto != null)
        {
            Console.WriteLine("Digite a nova quantidade:");
            int novaQuantidade = int.Parse(Console.ReadLine());
            produto.AtualizarQuantidade(novaQuantidade);

            Estoque estoque = estoques.Find(e => e.Nome == nome);
            if (estoque != null)
            {
                estoque.AtualizarQuantidade(novaQuantidade);
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    static void ExibirProduto()
    {
        Console.WriteLine("Digite o nome do produto para exibir:");
        string nome = Console.ReadLine();
        Produto produto = produtos.Find(p => p.Nome == nome);
        if (produto != null)
        {
            produto.ExibirDadosProduto();
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    static void VerificarValidadeProduto()
    {
        Console.WriteLine("Digite o nome do produto para verificar validade:");
        string nome = Console.ReadLine();
        Produto produto = produtos.Find(p => p.Nome == nome);
        if (produto != null)
        {
            if (produto.VerificarValidade())
                Console.WriteLine("Produto está dentro da validade.");
            else
                Console.WriteLine("Produto está vencido.");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    static void GerenciarEstoque()
    {
        Console.WriteLine("Digite o nome do produto para gerenciar o estoque:");
        string nome = Console.ReadLine();
        Estoque estoque = estoques.Find(e => e.Nome == nome);

        if (estoque != null)
        {
            bool voltarAoMenuEstoque = false;

            while (!voltarAoMenuEstoque)
            {
                Console.WriteLine("\nEscolha uma opção de estoque:");
                Console.WriteLine("1 - Exibir dados do estoque");
                Console.WriteLine("2 - Adicionar ao estoque");
                Console.WriteLine("3 - Reduzir do estoque");
                Console.WriteLine("4 - Verificar capacidade do estoque");
                Console.WriteLine("5 - Voltar ao menu de produto");

                int opcaoEstoque;
                if (int.TryParse(Console.ReadLine(), out opcaoEstoque))
                {
                    switch (opcaoEstoque)
                    {
                        case 1:
                            estoque.ExibirDadosEstoque();
                            break;
                        case 2:
                            Console.WriteLine("Digite a quantidade a ser adicionada:");
                            int adicionarQuantidade = int.Parse(Console.ReadLine());
                            estoque.AdicionarEstoque(adicionarQuantidade);
                            break;
                        case 3:
                            Console.WriteLine("Digite a quantidade a ser reduzida:");
                            int reduzirQuantidade = int.Parse(Console.ReadLine());
                            estoque.ReduzirEstoque(reduzirQuantidade);
                            break;
                        case 4:
                            estoque.VerificarCapacidade();
                            break;
                        case 5:
                            voltarAoMenuEstoque = true;
                            break;
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
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }
    static void MenuFuncionario()
    {
        bool voltarAoMenuPrincipal = false;

        while (!voltarAoMenuPrincipal)
        {
            Console.WriteLine("\nEscolha uma opção de funcionário:");
            Console.WriteLine("1 - Adicionar novo funcionário");
            Console.WriteLine("2 - Remover funcionário");
            Console.WriteLine("3 - Visualizar funcionário");
            Console.WriteLine("4 - Visualizar todos os funcionários");
            Console.WriteLine("5 - Atualizar dados de funcionário");
            Console.WriteLine("6 - Acessar funcionalidades de Funcionario Caixa");
            Console.WriteLine("7 - Acessar funcionalidades de Funcionario Lanche");
            Console.WriteLine("8 - Voltar ao menu principal");

            int opcaoFuncionario;
            if (int.TryParse(Console.ReadLine(), out opcaoFuncionario))
            {
                switch (opcaoFuncionario)
                {
                    case 1:
                        AdicionarFuncionario();
                        break;
                    case 2:
                        RemoverFuncionario();
                        break;
                    case 3:
                        VisualizarFuncionario();
                        break;
                    case 4:
                        VisualizarTodosFuncionarios();
                        break;
                    case 5:
                        AtualizarFuncionario();
                        break;
                    case 6:
                        FuncionarioCaixaMenu();
                        break;
                    case 7:
                        FuncionarioLancheMenu();
                        break;
                    case 8:
                        voltarAoMenuPrincipal = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }

    static void AdicionarFuncionario()
    {
        Console.WriteLine("\nAdicionar novo funcionário:");

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

        funcionarios.Add(new FuncionarioLanche(nome, cpf, rg, email, idade, telefone, sexo, cargo));
        Console.WriteLine("Funcionário adicionado com sucesso.");
    }

    static void RemoverFuncionario()
    {
        Console.Write("\nDigite o CPF do funcionário a ser removido: ");
        string cpfRemover = Console.ReadLine();
        Funcionario funcionarioRemover = funcionarios.Find(f => f.CPF == cpfRemover);

        if (funcionarioRemover != null)
        {
            funcionarios.Remove(funcionarioRemover);
            Console.WriteLine($"Funcionário {funcionarioRemover.Nome} removido com sucesso.");
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado.");
        }
    }

    static void VisualizarFuncionario()
    {
        Console.Write("\nDigite o CPF do funcionário a ser visualizado: ");
        string cpfVisualizar = Console.ReadLine();
        Funcionario funcionarioVisualizar = funcionarios.Find(f => f.CPF == cpfVisualizar);

        if (funcionarioVisualizar != null)
        {
            funcionarioVisualizar.VisualizarFuncionario();
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado.");
        }
    }

    static void VisualizarTodosFuncionarios()
    {
        Console.WriteLine("\nLista de todos os funcionários:");
        foreach (var funcionario in funcionarios)
        {
            funcionario.VisualizarFuncionario();
        }
    }

    static void AtualizarFuncionario()
    {
        Console.Write("\nDigite o CPF do funcionário para atualizar: ");
        string cpfAtualizar = Console.ReadLine();
        Funcionario funcionarioAtualizar = funcionarios.Find(f => f.CPF == cpfAtualizar);

        if (funcionarioAtualizar != null)
        {
            Console.Write("Digite o novo cargo: ");
            string novoCargo = Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado.");
        }
    }

    static void FuncionarioCaixaMenu()
    {
        Console.WriteLine("\nMenu de Funcionario Caixa:");
        Console.WriteLine("1 - Exibir dados do caixa");
        Console.WriteLine("2 - Calcular diferença de saldo");
        Console.WriteLine("3 - Verificar status do caixa");

        int opcaoCaixa;
        if (int.TryParse(Console.ReadLine(), out opcaoCaixa))
        {
            FuncionarioCaixa funcionarioCaixa = funcionarios.Find(f => f is FuncionarioCaixa) as FuncionarioCaixa;

            if (funcionarioCaixa != null)
            {
                switch (opcaoCaixa)
                {
                    case 1:
                        funcionarioCaixa.ExibirDadosCaixa();
                        break;
                    case 2:
                        double diferencaSaldo = funcionarioCaixa.CalcularDiferencaSaldo();
                        Console.WriteLine($"Diferença de saldo: {diferencaSaldo}");
                        break;
                    case 3:
                        string status = funcionarioCaixa.VerificarStatusCaixa();
                        Console.WriteLine($"Status do caixa: {status}");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Nenhum funcionário do tipo Caixa encontrado.");
            }
        }
    }

    static void FuncionarioLancheMenu()
    {
        Console.WriteLine("\nMenu de Funcionario Lanche:");
        Console.WriteLine("1 - Exibir dados do funcionário");
        Console.WriteLine("2 - Promover funcionário");
        Console.WriteLine("3 - Atualizar cargo do funcionário");

        int opcaoLanche;
        if (int.TryParse(Console.ReadLine(), out opcaoLanche))
        {
            FuncionarioLanche funcionarioLanche = funcionarios.Find(f => f is FuncionarioLanche) as FuncionarioLanche;

            if (funcionarioLanche != null)
            {
                switch (opcaoLanche)
                {
                    case 1:
                        funcionarioLanche.VisualizarFuncionario();
                        break;
                    case 2:
                        funcionarioLanche.PromoverFuncionario();
                        break;
                    case 3:
                        Console.Write("Digite o novo cargo: ");
                        string novoCargo = Console.ReadLine();
                        funcionarioLanche.AtualizarCargo(novoCargo);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Nenhum funcionário do tipo Lanche encontrado.");
            }
        }
    }

    static void MenuFilme()
    {

    }
    static void MenuCliente()
    {

    }
}