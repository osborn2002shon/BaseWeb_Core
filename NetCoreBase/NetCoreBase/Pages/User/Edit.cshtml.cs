using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreBase.Models.EF;

namespace NetCoreBase.Pages.User
{
    public class EditModel : PageModel
    {
        private readonly NetCoreBase.Models.EF.IftWebBaseContext _context;

        public EditModel(NetCoreBase.Models.EF.IftWebBaseContext context)
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

            var systemuseraccount =  await _context.SystemUserAccounts.FirstOrDefaultAsync(m => m.AccountId == id);
            if (systemuseraccount == null)
            {
                return NotFound();
            }
            SystemUserAccount = systemuseraccount;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            SystemUserAccount.UpdateDateTime = DateTime.UtcNow;
            // 附加您的實體到上下文並設定其狀態
            var entry = _context.Attach(SystemUserAccount);
            entry.State = EntityState.Modified;

            // 確保 InsertDateTime 沒有被修改
            entry.Property("InsertAccountId").IsModified = false;
            entry.Property("InsertDateTime").IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemUserAccountExists(SystemUserAccount.AccountId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SystemUserAccountExists(int id)
        {
          return (_context.SystemUserAccounts?.Any(e => e.AccountId == id)).GetValueOrDefault();
        }
    }
}
