using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CraftX.Class;

namespace CraftX.Pages.UserManagement
{
    public class UserManagementDetailsModel : PageModel
    {
        private readonly CraftX.Class.AppDbContext _context;

        public UserManagementDetailsModel(CraftX.Class.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
