using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CraftX.Class;
using System.Xml.Linq;

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
        public User Users { get; set; } = default!;

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
                Users = user;
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
                Users = user;
                _context.TBL_USERS.Remove(Users);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./UserManagementList");
        }
    }
}
