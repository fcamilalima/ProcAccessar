using ProcAccessar.Models;

namespace ProcAccessar.Repositories;

public interface ICategoriaRepository
{
    IEnumerable<Categoria> Categorias { get; }
    Categoria GetById(int categoriaId);

    void Add(Categoria categoria);
    void Update(Categoria categoria);
    void Delete(Categoria categoria);
}


