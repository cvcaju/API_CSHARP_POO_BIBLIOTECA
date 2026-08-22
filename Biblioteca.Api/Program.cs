
using Biblioteca.Api;
using Biblioteca.Dominio;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Redirect("/itens"));

var acervo = new Acervos();
var cadastro = new Cadastro();
Seed.Popular(acervo, cadastro);

app.MapGet("/itens", () => acervo.Itens);

app.Run();
