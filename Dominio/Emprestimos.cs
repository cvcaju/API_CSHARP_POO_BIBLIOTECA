namespace Biblioteca.Dominio;

public class Emprestimo
{
    private readonly Usuario _usuario;

    public Usuario Usuario => _usuario;
    public ItemAcervo Item { get; }
    public DateTime DataEmprestimo { get; }
    public DateTime PrazoLimite { get; }
    public DateTime? DataDevolucao { get; private set; }
    public decimal MultaPaga { get; private set; }

    public Emprestimo(ItemAcervo item, Usuario usuario, DateTime? dataEmprestimo = null)
    {
        usuario.Emprestar(item);
        _usuario = usuario;
        Item = item;
        DataEmprestimo = dataEmprestimo?.Date ?? DateTime.Today;
        PrazoLimite = DataEmprestimo.AddDays(item.PrazoDevolucao);
    }

    public decimal MultaAtual => DataDevolucao.HasValue ? MultaPaga : Item.CalcularMulta(QtdDiasAtrasados);

    public int QtdDiasAtrasados
    {
        get
        {
            TimeSpan diasAtrasados = DateTime.Today - PrazoLimite;

            return diasAtrasados.Days;
        }
    }

    public decimal RegistrarDevolucao(DateTime? dataDevolucao = null)
    {
        if (DataDevolucao.HasValue)
        {
            throw new ExcecaoDominio("Empréstimo já foi devolvido.");
        }

        DataDevolucao = dataDevolucao?.Date ?? DateTime.Today;
        MultaPaga = Item.CalcularMulta(Math.Max(0, (DataDevolucao.Value - PrazoLimite).Days));
        _usuario.Devolver(Item);
        return MultaPaga;
    }

}
