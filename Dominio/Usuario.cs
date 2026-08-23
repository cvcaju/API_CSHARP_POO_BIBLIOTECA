namespace Biblioteca.Dominio;

public class Usuario
{
    private const int LimiteItensEmprestados = 3;
    private readonly List<ItemAcervo> _itensEmprestados = [];

    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public int QuantidadeItensEmprestados => _itensEmprestados.Count;
    public IReadOnlyCollection<ItemAcervo> ItensEmprestados => _itensEmprestados.AsReadOnly();

    public Usuario(string nome, DateTime dataNascimento)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ExcecaoDominio("O nome é obrigatório");
        }

        Nome = nome;
        DataNascimento = dataNascimento;
    }

    public void Emprestar(ItemAcervo item)
    {
        

        if (_itensEmprestados.Count >= LimiteItensEmprestados)
        {
            throw new ExcecaoDominio("Usuário já atingiu o limite de 3 itens emprestados. Devolva um antes de pegar outro.");
        }

        if (!item.Disponibilidade)
        {
            throw new ExcecaoDominio($"O item '{item.Titulo}' já está emprestado.");
        }

        if (item is Dvd dvd && CalcularIdade() < IdadeMinima(dvd.FaixaEtaria))
        {
            throw new ExcecaoDominio($"Empréstimo não permitido: a idade mínima para este DVD é {IdadeMinima(dvd.FaixaEtaria)} anos.");
        }

        item.MarcarComoEmprestado();
        _itensEmprestados.Add(item);
    }

    private int CalcularIdade()
    {
        var hoje = DateTime.Today;
        var idade = hoje.Year - DataNascimento.Year;

        if (DataNascimento.Date > hoje.AddYears(-idade))
        {
            idade--;
        }

        return idade;
    }

    private static int IdadeMinima(FaixaEtaria faixaEtaria)
    {
        return faixaEtaria switch
        {
            FaixaEtaria.Livre => 0,
            FaixaEtaria.DozeAnos => 12,
            FaixaEtaria.QuatorzeAnos => 14,
            FaixaEtaria.DezesseisAnos => 16,
            FaixaEtaria.DezoitoAnos => 18,
            _ => throw new ArgumentOutOfRangeException(nameof(faixaEtaria))
        };
    }

    public void Devolver(ItemAcervo item)
    {
        

        if (!_itensEmprestados.Contains(item))
        {
            throw new ExcecaoDominio($"O item '{item.Titulo}' não está com este usuário.");
        }

        _itensEmprestados.Remove(item);
        item.MarcarComoDevolvido();
    }
}