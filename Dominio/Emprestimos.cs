namespace Biblioteca.Dominio;

public class Emprestimo
{
    public ItemAcervo Item { get; }
    public DateTime DataEmprestimo { get; private set; } = DateTime.Today;
    public DateTime PrazoLimite { get; }

    public Emprestimo(ItemAcervo item)
    {
        item.MarcarComoEmprestado();
        Item = item;
        PrazoLimite = DataEmprestimo.AddDays(item.PrazoDevolucao);
    }

    public decimal MultaAtual => Item.CalcularMulta();

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
