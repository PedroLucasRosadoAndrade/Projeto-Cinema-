public class Funcionario
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public string Email { get; set; }
    public int Idade { get; set; }
    public string Telefone { get; set; }
    public string Sexo { get; set; }
    public string Cargo { get; set; }

    public Funcionario(string nome, string cpf, string rg, string email, int idade, string telefone, string sexo, string cargo)
    {
        Nome = nome;
        CPF = cpf;
        RG = rg;
        Email = email;
        Idade = idade;
        Telefone = telefone;
        Sexo = sexo;
        Cargo = cargo;
    }

    public virtual void VisualizarFuncionario()
    {
        Console.WriteLine($"Nome: {Nome}, CPF: {CPF}, Cargo: {Cargo}, Idade: {Idade}, Sexo: {Sexo}, Telefone: {Telefone}, Email: {Email}");
        Console.WriteLine();
    }

    public static void AdicionarFuncionario(List<Funcionario> funcionarios, Funcionario novoFuncionario)
    {
        funcionarios.Add(novoFuncionario);
    }

    public static void RemoverFuncionario(List<Funcionario> funcionarios, string cpf)
    {
        Funcionario func = funcionarios.Find(f => f.CPF == cpf);
        if (func != null)
        {
            funcionarios.Remove(func);
            Console.WriteLine("Funcionário removido com sucesso.");
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado.");
        }
    }
    public static void AtualizarDados(Funcionario func, string nome, string email, string telefone, string sexo)
    {
        func.Nome = nome;
        func.Email = email;
        func.Telefone = telefone;
        func.Sexo = sexo;
        Console.WriteLine("Dados atualizados com sucesso.");
    }
}
