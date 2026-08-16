namespace Biblioteca.Dominio;

public class Dvd(string titulo, string autor, FaixaEtaria faixaEtaria) : ItemAcervo(titulo, autor)
{
   public FaixaEtaria FaixaEtaria { get; private set; } = faixaEtaria;

   public override int PrazoDevolucao => 3;

   public override decimal MultaDiariaAtrasado => 3m;

}

    