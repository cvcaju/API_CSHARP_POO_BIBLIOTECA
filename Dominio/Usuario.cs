namespace Biblioteca.Dominio;

public class Usuario
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }

    public Usuario(string nome, DateTime dataNascimento)

    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ExcecaoDominio("O nome é obrigatório");
        }

        Nome = nome;
        DataNascimento = dataNascimento;


    }

}