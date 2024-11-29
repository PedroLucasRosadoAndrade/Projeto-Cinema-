public class FuncionarioLanche : Funcionario
{
    public FuncionarioLanche(string nome, string cpf, string rg, string email, int idade, string telefone, string sexo, string cargo)
        : base(nome, cpf, rg, email, idade, telefone, sexo, cargo)
    {
    }

    public override void VisualizarFuncionario()
    {
        Console.WriteLine("Funcionário da Lanchonete:");
        base.VisualizarFuncionario();
    }

    public void AtualizarCargo(string novoCargo)
    {
        Cargo = novoCargo;
        Console.WriteLine($"Cargo do funcionário atualizado para: {Cargo}");
    }

    public void PromoverFuncionario()
    {
        if (Cargo.ToLower() == "atendente")
        {
            Cargo = "Supervisor";
            Console.WriteLine("Funcionário promovido para Supervisor.");
        }
        else
        {
            Console.WriteLine("Promoção não disponível para este cargo.");
        }
    }
}