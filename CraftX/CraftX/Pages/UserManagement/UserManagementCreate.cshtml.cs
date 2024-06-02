using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CraftX.Class;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CraftX.Pages.UserManagement
{
    public class UserManagementCreateModel : PageModel
    {
        private readonly CraftX.Class.AppDbContext _context;

        public UserManagementCreateModel(CraftX.Class.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User Users { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TBL_USERS.Add(Users);
            await _context.SaveChangesAsync();

            return RedirectToPage("./UserManagementList");
        }
    }
}
