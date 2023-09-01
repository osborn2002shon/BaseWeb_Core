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
    public class IndexModel : PageModel
    {
        private readonly NetCoreBase.Models.EF.IftWebBaseContext _context;

        public IndexModel(NetCoreBase.Models.EF.IftWebBaseContext context)
        {
            _context = context;
        }

        public IList<SystemUserAccount> SystemUserAccount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SystemUserAccounts != null)
            {
                SystemUserAccount = await _context.SystemUserAccounts.ToListAsync();
                
            }
        }
    }
}
