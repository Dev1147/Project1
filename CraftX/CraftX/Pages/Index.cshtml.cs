using CraftX.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
            InternalMemo = await _context.TBL_InternalMemos.OrderByDescending(u => u.MemoID).ToListAsync(); //LinQ로 내림차순 하기
            //InternalMemo = await _context.TBL_InternalMemos
            //    .Select((x, index) => new { InternalMemo = x, RowNumber = index + 1 }) // row_number를 추가
            //    .OrderByDescending(x => x.InternalMemo.MemoID) // MemoID를 기준으로 내림차순 정렬
            //    .Select(x => x.InternalMemo) // row_number를 추가한 후 필요 없어진 속성 제거
            //    .ToListAsync();
        }
    }
}
