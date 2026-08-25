namespace Biblioteca.Dominio;

public class Emprestimo
{
    private decimal? _multaFinalizada;

    public Usuario Usuario { get; }
    public ItemAcervo Item { get; }
    public DateTime DataEmprestimo { get; }
    public DateTime PrazoLimite { get; }
    public DateTime? DataDevolucao { get; private set; }
    public decimal MultaPaga { get; private set; }

    public Emprestimo(ItemAcervo item, Usuario usuario)
        : this(item, usuario, DateTime.Today)
    {
    }

    public Emprestimo(ItemAcervo item, Usuario usuario, DateTime dataEmprestimo)
    {
        Item = item;
        Usuario = usuario;
        DataEmprestimo = dataEmprestimo.Date;
        PrazoLimite = DataEmprestimo.AddDays(item.PrazoDevolucao);
        usuario.Emprestar(item);
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
           Usuario.Devolver(Item);
        _multaFinalizada = MultaPaga;
        return MultaPaga;
    }

}
