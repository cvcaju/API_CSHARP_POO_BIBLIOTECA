namespace Biblioteca.Dominio;

public abstract class ItemAcervo
{
    public ItemAcervo(string titulo, string autor)
    {
        if (string.IsNullOrWhiteSpace(titulo))

        {
            throw new ExcecaoDominio("O título é obrigatório");
        }
        Titulo = titulo;
        Autor = autor;
    }


    public string Titulo { get; private set; } = string.Empty;

    public string Autor { get; private set; } = string.Empty;
    public bool Disponibilidade { get; private set; } = true;

    public abstract int PrazoDevolucao { get; }

    public abstract decimal MultaDiariaAtrasado { get; }

    public decimal CalcularMulta(int diasAtrasados)
    {
        return diasAtrasados >= 0 ? diasAtrasados * MultaDiariaAtrasado : 0;
    }

    public void MarcarComoDevolvido()
    {
        if (Disponibilidade)
        {
            throw new ExcecaoDominio("Não está emprestado");
        }

        Disponibilidade = true;
    }

    public void MarcarComoEmprestado()

    {
        if (!Disponibilidade)

            throw new ExcecaoDominio("Não está emprestado");

        Disponibilidade = false;
    }

}

