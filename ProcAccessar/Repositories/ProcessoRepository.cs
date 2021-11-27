using Microsoft.EntityFrameworkCore;
using ProcAccessar.Context;
using ProcAccessar.Models;

namespace ProcAccessar.Repositories;

public class ProcessoRepository : IProcessoRepository
{
    private readonly AppDbContext _context;
    public ProcessoRepository(AppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Processo> Processos => _context.Processos;

    public void Add(Processo processo) => _context.Processos.Add(processo);

    public void Delete(Processo processo) => _context?.Processos.Remove(processo);

    public void Update(Processo processo)
    {
        _context.Entry(processo).State = EntityState.Modified;
        _context.Update(processo);
    }
}

