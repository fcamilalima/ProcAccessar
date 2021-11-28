using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcAccessar.Models;

[Table("tbCategoria")]
public class Categoria
{
    public int CategoriaId { get; set; }

    [Display(Name = "Categoria")]
    public string Descricao { get; set; }
}
