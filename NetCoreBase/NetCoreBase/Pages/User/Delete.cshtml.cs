using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetCoreBase.Models.EF;

namespace NetCoreBase.Pages.User
{
    public class DeleteModel : PageModel
    {
        private readonly NetCoreBase.Models.EF.IftWebBaseContext _context;

        public DeleteModel(NetCoreBase.Models.EF.IftWebBaseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SystemUserAccount SystemUserAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SystemUserAccounts == null)
            {
                return NotFound();
            }

            var systemuseraccount = await _context.SystemUserAccounts.FirstOrDefaultAsync(m => m.AccountId == id);

            if (systemuseraccount == null)
            {
                return NotFound();
            }
            else 
            {
                SystemUserAccount = systemuseraccount;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SystemUserAccounts == null)
            {
                return NotFound();
            }
            var systemuseraccount = await _context.SystemUserAccounts.FindAsync(id);

            if (systemuseraccount != null)
            {
                SystemUserAccount = systemuseraccount;
                _context.SystemUserAccounts.Remove(SystemUserAccount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
