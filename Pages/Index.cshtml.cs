using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Inlämning3Docker.Models;
using Inlämning3Docker.Services;

namespace Inlämning3Docker.Pages;

public class IndexModel(IDbService dbService) : PageModel
{
    private readonly IDbService _dbService = dbService;
    public IEnumerable<DbItem>? DbItems { get; private set; }
    public DbItem? NewItem { get; set; } = null;
    
    public async Task<IActionResult> OnGetAsync()
    {
        DbItems = await _dbService.GetAllAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return RedirectToPage();
        }
        var newItem = new DbItem { Name = name };
        await _dbService.CreateAsync(newItem);
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(string id)
    {
        await _dbService.DeleteAsync(id);
        return RedirectToPage();
    }
}
