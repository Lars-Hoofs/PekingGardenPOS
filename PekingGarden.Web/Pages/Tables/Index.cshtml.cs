using Microsoft.AspNetCore.Mvc.RazorPages;
using PekingGarden.Logic;
using PekingGarden.Logic.Services;

namespace PekingGarden.Web.Pages.Tables;

public class IndexModel : PageModel
{
    private readonly TableService tableService;

    public List<TableStatus> Tables { get; private set; } = new List<TableStatus>();
    public List<TableStatus> DrinksBills { get; private set; } = new List<TableStatus>();
    public int OpenCount { get; private set; }

    public IndexModel(TableService tableService)
    {
        this.tableService = tableService;
    }

    public void OnGet()
    {
        List<TableStatus> overview = tableService.GetOverview();

        Tables = overview.Where(status => !status.Table.IsDrinksBill).ToList();
        DrinksBills = overview.Where(status => status.Table.IsDrinksBill).ToList();
        OpenCount = Tables.Count(status => status.IsOpen);
    }
}