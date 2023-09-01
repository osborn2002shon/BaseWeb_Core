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
    public class DetailsModel : PageModel
    {
        private readonly NetCoreBase.Models.EF.IftWebBaseContext _context;

        public DetailsModel(NetCoreBase.Models.EF.IftWebBaseContext context)
        {
            _context = context;
        }

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
    }
}
