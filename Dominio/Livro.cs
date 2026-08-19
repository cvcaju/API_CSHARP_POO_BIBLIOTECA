namespace Biblioteca.Dominio;

public class Livros(string titulo, string autor) : ItemAcervo(titulo, autor)
{
   public override int PrazoDevolucao => 14;

   public override decimal MultaDiariaAtrasado => 1m;

}ggggggg
