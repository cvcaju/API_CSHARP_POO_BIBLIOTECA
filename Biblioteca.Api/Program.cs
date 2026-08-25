
using Biblioteca.Api;
using Biblioteca.Dominio;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var acervo = new Acervos();
var cadastro = new Cadastro();
Seed.Popular(acervo, cadastro);
var emprestimos = new List<Emprestimo>();

app.MapGet("/", () => Results.Redirect("/itens"));

app.MapGet("/itens", () => acervo.Itens);

app.MapGet("/itens/{id:int}", (int id) => 

{
    var item = acervo.BuscarPorId(id);

    if( item is null)

    {
       return Results.NotFound(new { erro = $"o {id} do Item não foi encontrado!"});
    }

  return Results.Ok(item);         

});

app.MapGet("/usuario", () => cadastro.Itens.Select(Usuario => new

{
    Usuario.Id,
    Usuario.DataNascimento,
    Usuario.Nome,
    EmprestimoEmAberto = Usuario.ItensEmprestados

}));

app.Run();

