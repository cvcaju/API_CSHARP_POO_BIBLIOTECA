namespace Biblioteca.Dominio;

public abstract class ItemAcervo
{
    private static int _proximoId = 1;
    public int Id { get; }
    public ItemAcervo(string titulo, string autor)

    {
        if (string.IsNullOrWhiteSpace(titulo))
        {
            throw new ExcecaoDominio("O título é obrigatório");
        }
        
        if (string.IsNullOrWhiteSpace(autor))
        {
            throw new ExcecaoDominio("O autor é obrigatório");
        }
        
        Titulo = titulo;
        Autor = autor;
        Id = _proximoId++;
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
            throw new ExcecaoDominio("Item não está emprestado.");
        }

        Disponibilidade = true;
    }

    public void MarcarComoEmprestado()
    {
        if (!Disponibilidade)
        {
            throw new ExcecaoDominio("Item já está emprestado.");
        }

        Disponibilidade = false;
    }

}

