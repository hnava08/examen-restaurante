using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Pages.Categorias;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Categoria> Categorias { get; set; } = new List<Categoria>();

    public async Task OnGetAsync()
    {
        Categorias = await _context.Categorias
            .OrderBy(c => c.Nombre)
            .ToListAsync();
    }
}
