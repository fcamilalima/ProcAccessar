using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcAccessar.Models;

[Table("tbProcesso")]
public class Processo
{
    public int ProcessoId { get; set; }
    [Display(Name = "Cód.")]
    public int Codigo { get; set; }

    [Display(Name = "Título")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.")]
    public string Titulo { get; set; }

    [Display(Name = "Descrição")]
    [StringLength(200, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.")]
    public string Descricao { get; set; }

    [Display(Name = "Data")]
    [DataType(DataType.Date, ErrorMessage = "A data foi prenchida!")]
    public DateTime? DataCriacao { get; set; }
    public int CategoriaId { get; set; }


    [Display(Name = "Categoria")]
    public virtual IEnumerable<Categoria> Categorias { get; set; }
}

