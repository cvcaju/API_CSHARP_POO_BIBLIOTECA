namespace Biblioteca.Dominio;

public class Emprestimo
{
    public Usuario Usuario { get; }
    public ItemAcervo Item { get; }
    public DateTime DataEmprestimo { get; private set; } = DateTime.Today;
    public DateTime PrazoLimite { get; }

    public Emprestimo(ItemAcervo item, Usuario usuario)
    {
        item.MarcarComoEmprestado();
        Item = item;
        PrazoLimite = DataEmprestimo.AddDays(item.PrazoDevolucao);
        Usuario = usuario;
    }

    public decimal MultaAtual => Item.CalcularMulta(QtdDiasAtrasados);

    public int QtdDiasAtrasados
    {
        get
        {
            TimeSpan diasAtrasados = DateTime.Today - PrazoLimite;

            return diasAtrasados.Days;
        }
    }

    public void RegistrarDevolucao() 
    {
       
         Item.MarcarComoDevolvido();
    }

}
