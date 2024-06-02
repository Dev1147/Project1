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
            InternalMemo = await _context.TBL_InternalMemos.OrderByDescending(u => u.MemoID).ToListAsync(); //LinQ�� �������� �ϱ�
            //InternalMemo = await _context.TBL_InternalMemos
            //    .Select((x, index) => new { InternalMemo = x, RowNumber = index + 1 }) // row_number�� �߰�
            //    .OrderByDescending(x => x.InternalMemo.MemoID) // MemoID�� �������� �������� ����
            //    .Select(x => x.InternalMemo) // row_number�� �߰��� �� �ʿ� ������ �Ӽ� ����
            //    .ToListAsync();
        }
    }
}
