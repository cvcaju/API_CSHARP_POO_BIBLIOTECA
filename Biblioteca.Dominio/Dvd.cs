namespace Biblioteca.Dominio;

public class Dvd(string titulo, string autor, FaixaEtaria faixaEtaria) : ItemAcervo(titulo, autor)
{
   public FaixaEtaria FaixaEtaria { get; private set; } = faixaEtaria;

   public int IdadeMinima => FaixaEtaria switch
   {
      FaixaEtaria.Livre => 0,
      FaixaEtaria.DozeAnos => 12,
      FaixaEtaria.QuatorzeAnos => 14,
      FaixaEtaria.DezesseisAnos => 16,
      FaixaEtaria.DezoitoAnos => 18,
      _ => 0
   };

   public override int PrazoDevolucao => 3;

   public override decimal MultaDiariaAtrasado => 3m;

}

    