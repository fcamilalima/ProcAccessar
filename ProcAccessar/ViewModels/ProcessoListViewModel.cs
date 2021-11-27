using ProcAccessar.Models;
using System.ComponentModel.DataAnnotations;

namespace ProcAccessar.ViewModels;

public class ProcessoListViewModel
{
    [Required(ErrorMessage = "O código do processo é obrigatório!")]
    [Display(Name = "Cod. Processo")]
    public int Codigo { get; set; }

    [Required(ErrorMessage = "Título requerido!")]
    [Display(Name = "Título")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Faça uma breve descrição")]
    [Display(Name = "Descrição")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Escolha uma data!")]
    [Display(Name = "Data do Processo")]
    [DataType(DataType.Date, ErrorMessage = "Data em formato inválido!")]
    public DateTime? DataCriacao { get; set; }

    public virtual Categoria Categorias { get; set; }
    public virtual IEnumerable<Categoria> Categoria { get; set; }
}

