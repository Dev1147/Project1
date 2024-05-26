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
    public class UserManagementModel : PageModel
    {
        private readonly CraftX.Class.AppDbContext _context;

        public UserManagementModel(CraftX.Class.AppDbContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _context.TBL_USERS.OrderByDescending(u => u.JOINDATE).ToListAsync(); //LinQ로 내림차순 하기
        }
    }
}
