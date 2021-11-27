using ProcAccessar.Models;

namespace ProcAccessar.Repositories;

public interface IProcessoRepository
{
    IEnumerable<Processo> Processos { get; }
    void Add(Processo processo);
    void Update(Processo processo);
    void Delete(Processo processo);
}

