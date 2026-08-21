namespace Biblioteca.Dominio;

public class Usuario
{
    private static int _proximoId = 1;
    public int Id { get; }
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
        Id = _proximoId++;
    }

    public void Emprestar(ItemAcervo item)
    {
        

        if (_itensEmprestados.Count >= LimiteItensEmprestados)
        {
            throw new ExcecaoDominio("Usuário já atingiu o limite de 3 itens emprestados. Devolva um antes de pegar outro.");
        }

         item.MarcarComoEmprestado();
        _itensEmprestados.Add(item);
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