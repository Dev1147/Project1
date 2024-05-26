using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CraftX.Class;

namespace CraftX.Pages.UserManagements
{
    public class UserManagementDeleteModel : PageModel
    {
        private readonly CraftX.Class.AppDbContext _context;

        public UserManagementDeleteModel(CraftX.Class.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.TBL_USERS.FirstOrDefaultAsync(m => m.USERID == id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = user;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.TBL_USERS.FindAsync(id);
            if (user != null)
            {
                User = user;
                _context.TBL_USERS.Remove(User);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./UserManagementList");
        }
    }
}
