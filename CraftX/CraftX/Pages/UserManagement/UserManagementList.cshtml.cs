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
           /*
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
            }).ToList(); //메모리안에서 저장하여 반환하기 때문에 대용량 DB일때 단점이 있다
           */

            IQueryable<User> data = _context.TBL_USERS.OrderByDescending(x => x.JOINDATE);

            var userList = await data.ToListAsync(); //비동기 사용

            Users = userList.AsEnumerable().Select((x, index) => new User
            {
                RowNumber = index + 1, // 행 번호는 1부터 시작
                NICKNAME = x.NICKNAME,
                EMAIL = x.EMAIL,
                JOINDATE = x.JOINDATE,
                USERAUTH = x.USERAUTH
            }).ToList(); //IQueryable을 사용하여 지연 로드를 함. ToList() 또는 ToListAsync()에 올때 DB에서 돌아가 대용량에 장점

        }
    }
}
