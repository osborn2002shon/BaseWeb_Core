using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetCoreBase.Models.EF;

namespace NetCoreBase.Pages.User
{
    public class CreateModel : PageModel
    {
        private readonly NetCoreBase.Models.EF.IftWebBaseContext _context;

        public CreateModel(NetCoreBase.Models.EF.IftWebBaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SystemUserAccount SystemUserAccount { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SystemUserAccounts == null || SystemUserAccount == null)
            {
                return Page();
            }
            SystemUserAccount.InsertDateTime = DateTime.Now;

            _context.SystemUserAccounts.Add(SystemUserAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
