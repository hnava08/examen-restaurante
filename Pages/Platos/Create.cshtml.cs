using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Platos;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Plato Plato { get; set; } = new();

    public SelectList CategoriasSelectList { get; set; } = null!;

    public IActionResult OnGet()
    {
        CargarCategorias();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            CargarCategorias();
            return Page();
        }

        _context.Platos.Add(Plato);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }

    private void CargarCategorias()
    {
        CategoriasSelectList = new SelectList(_context.Categorias.OrderBy(c => c.Nombre), "Id", "Nombre");
    }
}
