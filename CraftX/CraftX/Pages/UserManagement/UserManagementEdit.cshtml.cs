using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CraftX.Class;

namespace CraftX.Pages.UserManagement
{
    public class UserManagementEditModel : PageModel
    {
        private readonly CraftX.Class.AppDbContext _context;

        public UserManagementEditModel(CraftX.Class.AppDbContext context)
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

            var user =  await _context.TBL_USERS.FirstOrDefaultAsync(m => m.USERID == id);
            if (user == null)
            {
                return NotFound();
            }
            Users = user;
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

            _context.Attach(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(Users.USERID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./UserManagementList");
        }

        private bool UserExists(string id)
        {
            return _context.TBL_USERS.Any(e => e.USERID == id);
        }
    }
}
