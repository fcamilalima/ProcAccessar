using Microsoft.EntityFrameworkCore;
using ProcAccessar.Context;
using ProcAccessar.Models;

namespace ProcAccessar.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Categoria> Categorias => _context.Categorias;

        public void Add(Categoria categoria) => _context.Categorias.Add(categoria);

        public void Update(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            _context.Update(categoria);
        }
        public void Delete(Categoria categoria) => _context.Remove(categoria);
        
        public Categoria GetById(int categoriaId) => _context.Categorias.SingleOrDefault(c => c.CategoriaId == categoriaId);
       
    }
}
