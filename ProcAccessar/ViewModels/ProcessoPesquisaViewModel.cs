using Microsoft.EntityFrameworkCore;
using ProcAccessar.Models;

namespace ProcAccessar.ViewModels;

[Keyless]
public class ProcessoPesquisaViewModel
{
    public List<Processo>? Processos { get; set; }
    public string? PalavraBusca { get; set; }
}

