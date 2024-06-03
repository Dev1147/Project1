using CraftX.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CraftX.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        private readonly CraftX.Class.AppDbContext _context;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
        public IndexModel(CraftX.Class.AppDbContext context)
        {
            _context = context;
        }
        public IList<InternalMemos> InternalMemo { get; set; }

        //public void OnGet()
        //{

        //}
        public async Task OnGetAsync()
        {
            //InternalMemo = await _context.TBL_InternalMemos.OrderByDescending(u => u.MemoID).Take(5).ToListAsync(); //LinQ로 5개 고정하고 내림차순 하기
            
            //InternalMemo = await _context.TBL_InternalMemos.OrderByDescending(u => u.CreatedDate) //내림차순
            //                    .Take(5) // 5개만 뽑기
            //                    .Select((x, index) => new InternalMemos
            //                    {
            //                        RowNumber = index + 1,
            //                        Title = x.Title,
            //                        CreatedDate = x.CreatedDate,
            //                        Writer = x.Writer
            //                    })
            //                    .ToListAsync(); //데이터 베이스에서
            // 가공해야 되어 안되는건가??


            // 서버에서 데이터를 가져옴
            var query = await _context.TBL_InternalMemos.OrderByDescending(u => u.CreatedDate).Take(5).ToListAsync();

            // 클라이언트 쪽에서 행 번호를 추가
            InternalMemo = query.Select((x, index) => new InternalMemos
            {
                RowNumber = index + 1, // 행 번호는 1부터 시작
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                Writer = x.Writer
            }).ToList(); //메모리안에서

        }
    }
}
