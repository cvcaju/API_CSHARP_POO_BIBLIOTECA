
using Biblioteca.Api;
using Biblioteca.Dominio;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Redirect("/itens"));

var acervo = new Acervos();
var cadastro = new Cadastro();
Seed.Popular(acervo, cadastro);
var emprestimos = new List<Emprestimo>();

app.MapGet("/itens", () => acervo.Itens);

app.MapGet("/usuarios", () => cadastro.Itens);

app.MapGet("/emprestimos", () => emprestimos.Select((emprestimo, indice) => new
{
	Id = indice + 1,
	UsuarioId = emprestimo.Usuario.Id,
	ItemId = emprestimo.Item.Id,
	emprestimo.Item.Titulo,
	emprestimo.DataEmprestimo,
	emprestimo.PrazoLimite,
	emprestimo.DataDevolucao,
	Multa = emprestimo.MultaAtual
}));

app.MapPost("/emprestimos", (CriarEmprestimoRequest request) =>
{
	var usuario = cadastro.BuscarPorId(request.UsuarioId);
	var item = acervo.BuscarPorId(request.ItemId);

	if (usuario is null || item is null)
	{
		return Results.NotFound("Usuário ou item não encontrado.");
	}

	try
	{
		var emprestimo = new Emprestimo(item, usuario, request.DataEmprestimo ?? DateTime.Today);
		emprestimos.Add(emprestimo);
		return Results.Created($"/emprestimos/{emprestimos.Count}", new
		{
			Id = emprestimos.Count,
			UsuarioId = emprestimo.Usuario.Id,
			ItemId = emprestimo.Item.Id,
			emprestimo.PrazoLimite
		});
	}
	catch (ExcecaoDominio excecao)
	{
		return Results.BadRequest(excecao.Message);
	}
});

app.MapPost("/emprestimos/{id:int}/devolucao", (int id, RegistrarDevolucaoRequest? request) =>
{
	if (id < 1 || id > emprestimos.Count)
	{
		return Results.NotFound("Empréstimo não encontrado.");
	}

	try
	{
		var multa = emprestimos[id - 1].RegistrarDevolucao(request?.DataDevolucao);
		return Results.Ok(new { MultaPaga = multa });
	}
	catch (ExcecaoDominio excecao)
	{
		return Results.BadRequest(excecao.Message);
	}
});

app.Run();

public record CriarEmprestimoRequest(int UsuarioId, int ItemId, DateTime? DataEmprestimo = null);
public record RegistrarDevolucaoRequest(DateTime? DataDevolucao = null);
