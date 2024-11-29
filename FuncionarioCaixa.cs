public class FuncionarioCaixa : Funcionario
{
    public DateTime DataInic { get; set; }
    public string HoraAbertura { get; set; }
    public string HoraFechamento { get; set; }
    public double SaldoInic { get; set; }
    public double SaldoFinal { get; set; }
    public int IdFunc { get; set; }

    public FuncionarioCaixa(string nome, string cpf, string rg, string email, int idade, string telefone, string sexo,
                             DateTime dataInic, string horaAbertura, string horaFechamento, double saldoInic, double saldoFinal, int idFunc)
        : base(nome, cpf, rg, email, idade, telefone, sexo, "Caixa")
    {
        DataInic = dataInic;
        HoraAbertura = horaAbertura;
        HoraFechamento = horaFechamento;
        SaldoInic = saldoInic;
        SaldoFinal = saldoFinal;
        IdFunc = idFunc;
    }

    public double CalcularDiferencaSaldo()
    {
        return SaldoInic - SaldoFinal;
    }

    public string VerificarStatusCaixa()
    {
        if (SaldoInic == SaldoFinal)
            return "Caixa fechado corretamente.";
        else
            return "Discrepância no caixa.";
    }

    public void ExibirDadosCaixa()
    {
        Console.WriteLine($"Funcionário Caixa: {Nome}, Saldo Inicial: {SaldoInic}, Saldo Final: {SaldoFinal}, Hora Abertura: {HoraAbertura}, Hora Fechamento: {HoraFechamento}");
    }

    public override void VisualizarFuncionario()
    {
        base.VisualizarFuncionario();
        Console.WriteLine($"Caixa: {IdFunc}, Data Início: {DataInic}, Hora Abertura: {HoraAbertura}, Hora Fechamento: {HoraFechamento}");
    }
}