namespace Biblioteca.Api;

using Biblioteca.Dominio;
public static class Seed

{
    public static void Popular(Acervos acervo, Cadastro cadastro)

    {
        acervo.AdicionarItem(new Livros("Dom Casmurro", "Machado de Assis"));
        acervo.AdicionarItem(new Livros("Vidas Secas", "Graciliano Ramos"));
        acervo.AdicionarItem(new Revista("Superinteressante", "Editora Abril"));
        acervo.AdicionarItem(new Dvd("Toy Story", "John Lasseter", 0));
        acervo.AdicionarItem(new Dvd("Cidade de Deus", "Fernando Meirelles", FaixaEtaria.DezoitoAnos));

        cadastro.AdicionarItem(new Usuario("Marina", DateTime.Today.AddYears(-15)));
        cadastro.AdicionarItem(new Usuario("Caio", DateTime.Today.AddYears(-30)));
    }

    
}