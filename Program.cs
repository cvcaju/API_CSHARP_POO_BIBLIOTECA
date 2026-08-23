
using Biblioteca.Dominio;

var marina = new Usuario("Marina", new DateTime(2011, 1, 1));
var dvd = new Dvd("Filme classificado para 16 anos", "Distribuidora", FaixaEtaria.DezesseisAnos);

try
{
	marina.Emprestar(dvd);
	Console.WriteLine("Marina levou o DVD.");
}
catch (ExcecaoDominio excecao)
{
	Console.WriteLine($"Marina não levou: {excecao.Message}");
}

var caio = new Usuario("Caio", new DateTime(1990, 1, 1));
var itens = new ItemAcervo[]
{
	new Livros("Livro 1", "Autor 1"),
	new Livros("Livro 2", "Autor 2"),
	new Livros("Livro 3", "Autor 3"),
	new Livros("Livro 4", "Autor 4")
};

try
{
	caio.Emprestar(itens[0]);
	caio.Emprestar(itens[1]);
	caio.Emprestar(itens[2]);
	caio.Emprestar(itens[3]);
}
catch (ExcecaoDominio excecao)
{
	Console.WriteLine($"Caio, quarta tentativa: {excecao.Message}");
}

caio.Devolver(itens[0]);
caio.Emprestar(itens[3]);
Console.WriteLine("Caio, após devolver uma coisa: empréstimo realizado.");

var outroUsuario = new Usuario("Outro usuário", new DateTime(1990, 1, 1));
try
{
	outroUsuario.Emprestar(itens[1]);
}
catch (ExcecaoDominio excecao)
{
	Console.WriteLine($"Item já emprestado: {excecao.Message}");
}

var elias = new Usuario("Sr. Elias", new DateTime(1960, 1, 1));
var revista = new Revista("Revista histórica", "Editora");
var emprestimo = new Emprestimo(revista, elias, new DateTime(2026, 1, 1));
var multaPaga = emprestimo.RegistrarDevolucao(new DateTime(2026, 1, 20));
Console.WriteLine($"Sr. Elias pagou: R$ {multaPaga:F2}");
Console.WriteLine($"Duas semanas depois, devia: R$ {emprestimo.MultaAtual:F2}");

