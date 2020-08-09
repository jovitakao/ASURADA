using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASURADA.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASURADA.Web.Pages
{
    public class QueryDatabaseModel : PageModel
    {
        public string SelectedDatabase { get; set; }
        public List<SelectListItem> Databases { get; set; }
        public List<string> Tables { get; set; }

        public async Task OnGet()
        {
            var datasource = DataSourceFactory.Create(Program.DataSource);
            var databases=await datasource.GetDatabases("*");
            Databases= databases.Select(x => new SelectListItem(x, x)).ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}