
using Biblioteca.Dominio;

ItemAcervo livro = new Livros("O Senhor dos Anéis", "J.R.R. Tolkien");

ItemAcervo Margens = new Livros("Nas margens do rio Piedras eu sentei e chorei", "Paulo Colelho");

ItemAcervo Principe = new Livros("O Pequeno Príncipe", "Antoine de Saint-Exupéry");

ItemAcervo Memorias = new Livros("Memórias Póstumas de Brás Cubas", "Machado de Assis");

ItemAcervo Estrela = new Livros("Mistério do Cinco Estrelas", "Marcos Reys");

ItemAcervo Aventura = new Livros("Aventuras de Sherlock Holmes", "Arthur Conan Doyle");

ItemAcervo Eletronica = new Revista("Eletrônica", "Senai");

ItemAcervo Palavras = new Revista("Palavras Cruzadas", "Autor Desconhecido");

ItemAcervo Raul = new Dvd("Rock Roll", "Raul Seixas", FaixaEtaria.DezesseisAnos);

Usuario marina = new("Marina", new DateTime(2011, 1, 1));

Dvd dvd = new("Rock Roll", "Raul Seixas", FaixaEtaria.DezesseisAnos);

try
{
    marina.Emprestar(dvd);
    Console.WriteLine("Empréstimo liberado.");
}
catch (ExcecaoDominio ex)
{
    Console.WriteLine(ex.Message);
}

var livroNovo = new Livros("O Cortiço", "Aluísio Azevedo");
var revistaNova = new Revista("Piauí", "Alvinegra");
Console.WriteLine($"Cena 6 - {livroNovo.Titulo} e o Id {livroNovo.Id}, " +
                  $"{revistaNova.Titulo} e o Id {revistaNova.Id}");




