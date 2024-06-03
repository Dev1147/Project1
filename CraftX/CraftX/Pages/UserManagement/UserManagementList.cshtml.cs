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

        public IList<User> Users { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //Users = await _context.TBL_USERS.OrderByDescending(u => u.JOINDATE).ToListAsync(); //LinQ로 내림차순 하기

            // 서버에서 데이터를 가져옴
            var query = await _context.TBL_USERS.OrderByDescending(u => u.JOINDATE).ToListAsync();

            // 클라이언트 쪽에서 행 번호를 추가
            Users = query.Select((x, index) => new User
            {
                RowNumber = index + 1, // 행 번호는 1부터 시작
                NICKNAME = x.NICKNAME,
                EMAIL = x.EMAIL,
                JOINDATE = x.JOINDATE,
                USERAUTH = x.USERAUTH
            }).ToList(); //메모리안에서
        }
    }
}
