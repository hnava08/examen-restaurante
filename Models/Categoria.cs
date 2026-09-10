using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models;

public class Categoria
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100)]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(250)]
    [Display(Name = "Descripcion")]
    public string? Descripcion { get; set; }

    public ICollection<Plato> Platos { get; set; } = new List<Plato>();
}
