using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Platos;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Plato Plato { get; set; } = new();

    public SelectList CategoriasSelectList { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var plato = await _context.Platos.FindAsync(id);
        if (plato == null)
        {
            return NotFound();
        }

        Plato = plato;
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

        _context.Attach(Plato).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Platos.Any(e => e.Id == Plato.Id))
            {
                return NotFound();
            }
            throw;
        }

        return RedirectToPage("./Index");
    }

    private void CargarCategorias()
    {
        CategoriasSelectList = new SelectList(_context.Categorias.OrderBy(c => c.Nombre), "Id", "Nombre");
    }
}
