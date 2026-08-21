using Biblioteca.Dominio;

namespace Biblioteca.Api;

public class Cadastro
{
    private readonly List<Usuario> _itens = [];

    public IReadOnlyList<Usuario> Itens => _itens;

    public void AdicionarItem(Usuario usuario)
    {
        _itens.Add(usuario);
    }
    public Usuario? BuscarPorId(int id)
    {
        return _itens.FirstOrDefault(usuario => usuario.Id == id);
    }

    
}
